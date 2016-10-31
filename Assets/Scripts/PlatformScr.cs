using UnityEngine;
using System.Collections;

public class PlatformScr : MonoBehaviour {


    
    float backSpeed = 5.0f; 
    // Use this for initialization
    void Start ()
    {
       backSpeed = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PlatformSpeed;
    }
	
	// Update is called once per frame
	void Update ()
    {
      Vector3 newPos = new Vector3(transform.position.x , transform.position.y , transform.position.z + backSpeed);
      transform.position = newPos;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            GameObject tempPlayer = col.gameObject;

            this.GetComponent<Renderer>().material.color = Color.yellow;

        }

    }
}
