using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlatformSpawnerSCR : MonoBehaviour {

    public GameObject platformRef;
    public float freqenecy;
    public GameObject button;

    float timer;

    public List<GameObject> l_platforms = new List<GameObject>();    

	void Start ()
    {
        timer = 0.0f;
    }
	
	
	void Update ()
    {
        float q_width = this.transform.localScale.x;
        
        timer += Time.deltaTime;
        if (timer >= freqenecy)
        {
           timer = 0.0f;

           int spotNumber = Random.Range(0,4);
            float spawnX = ( (spotNumber * q_width / 2.0f) / 2.0f ) - (transform.localScale.x / 2.0f);
            button.GetComponentInChildren<Text>().text = spawnX.ToString();
            
            Vector3 newPos = new Vector3(transform.position.x + spawnX, transform.position.y, transform.position.z);
            platformRef.name = "newPlat";
            platformRef.transform.position = newPos;
            platformRef.name = platformRef.name + l_platforms.Count;
            // platformRef.transform.position.Set(platformRef.transform.position.x + spawnX, this.transform.position.y, this.transform.position.z);
            Instantiate(platformRef);
           // l_platforms.Add(GameObject.Instantiate(platformRef));
        }
	}
}
