using UnityEngine;
using System.Collections;


public class PlatformScr : MonoBehaviour {


    bool touching = false;
    float backSpeed = 5.0f;
 
    // Use this for initialization
    void Start ()
    {
       backSpeed = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PlatformSpeed;
      
    }
	
	// Update is called once per frame
	void Update ()
    {
      // mvoe the platform
      Vector3 newPos = new Vector3(transform.position.x , transform.position.y , transform.position.z + backSpeed);
      transform.position = newPos;

     

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {

            GameObject tempPlayer = col.gameObject;
            float pushUpDistance = this.transform.localScale.y ;
            Vector3 newPos = new Vector3(tempPlayer.transform.position.x, tempPlayer.transform.position.y + pushUpDistance, tempPlayer.transform.position.z);
            float time = 1.0f;
            var i = 0.0f;
            var rate = 1.0f / time;
            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                tempPlayer.transform.position = Vector3.Lerp(tempPlayer.transform.position, newPos, i);
            }
            this.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    void OnCollisionEnter(Collision col)
    {
       
    }
}
