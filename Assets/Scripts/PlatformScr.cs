using UnityEngine;
using System.Collections;


public class PlatformScr : MonoBehaviour {


    bool touching = false;

    float backSpeed;
    GameObject playerRef;

    float entryOffestZ;
    

    Light light;
    // Use this for initialization
    void Start ()
    {
       backSpeed = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PlatformSpeed;
        light = GetComponentInChildren<Light>();
        light.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
      // mvoe the platform
      Vector3 newPos = new Vector3(transform.position.x , transform.position.y , transform.position.z + backSpeed);
      transform.position = newPos;
       
        //if the player is on the platform
        if (touching)
        {
            GameObject tempPlayer = GameObject.FindGameObjectWithTag("player");
            float zOffset = tempPlayer.transform.position.z - transform.position.z;
            newPos = new Vector3(tempPlayer.transform.position.x, tempPlayer.transform.position.y, transform.position.z + entryOffestZ);

            tempPlayer.transform.position = newPos;
        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "player")
        {
          
            GameObject tempPlayer = col.gameObject;
            float zOffset =   tempPlayer.transform.position.z - transform.position.z ;
            Vector3 newPos = new Vector3(tempPlayer.transform.position.x, tempPlayer.transform.position.y , tempPlayer.transform.position.z + zOffset);
            tempPlayer.transform.position = newPos;
            // global var to signify per frame move
            touching = true;

            entryOffestZ = zOffset;

            // make light on platform turn on
            light.enabled = true;



            /*
            // force push up 
            float pushUpDistance = 0.0f; // set to 0 for debigging
            Vector3 newPos = new Vector3(tempPlayer.transform.position.x, tempPlayer.transform.position.y + pushUpDistance, tempPlayer.transform.position.z);
            Vector3 newPos = new Vector3(tempPlayer.transform.position.x, tempPlayer.transform.position.y,  transform.position.z);
            float time = 1.0f;
            var i = 0.0f;
            var rate = 1.0f / time;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                tempPlayer.transform.position = Vector3.Lerp(tempPlayer.transform.position, newPos, i);
            }
            */
            
    this.GetComponent<Renderer>().material.color = Color.yellow;
        
    }
    }

    void OnTriggerExit()
    {
        touching = false;
    }

    void OnCollisionEnter(Collision col)
    {
       
    }
}
