using UnityEngine;
using System.Collections;

public class PlatformDestroyScr : MonoBehaviour {

    // Use this for initialization
    GameObject spawnerRef;
	void Start () {
        //  BoxCollider boxCollider = this.GetComponent<BoxCollider>();
        spawnerRef = GameObject.FindGameObjectWithTag("PlatformSpawner");
	}
	
	// Update is called once per frame
	void Update () {
       
    }
  

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Untagged")
            return;
         
        if (col.gameObject.tag == "platform")
        {
            Destroy(col.gameObject);
          /*  if (spawnerRef)
            {
                foreach (GameObject platform in spawnerRef.GetComponent<PlatformSpawnerSCR>().l_platforms)
                {
                     if (platform.name == col.gameObject.name)
                    {
                        spawnerRef.GetComponent<PlatformSpawnerSCR>().l_platforms.Remove(platform);
                       
                    }

                } 
            }
            */
        }
    }

}
