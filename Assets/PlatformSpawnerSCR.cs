using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlatformSpawnerSCR : MonoBehaviour {

    public GameObject platformRef;
    public float freqenecy;

    float timer;

    List<GameObject> l_platforms = new List<GameObject>();    

	void Start ()
    {
        timer = 0.0f;
    }
	
	
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= freqenecy)
        {
            timer = 0.0f;

            // spawn stuff

            l_platforms.Add(GameObject.Instantiate(platformRef));


        }


	}
}
