using UnityEngine;
using System.Collections;

public class BounceBackScr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            GameObject tempPlayer = col.gameObject; 
            float pushUpDistance = 1.0f;
         //   tempPlayer.transform.position = newPos;
            Vector3 newPos = new Vector3(tempPlayer.transform.position.x, tempPlayer.transform.position.y + pushUpDistance, tempPlayer.transform.position.z);

            float time = 1.0f;
            var i = 0.0f;
            var rate = 1.0f / time; 
            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                tempPlayer.transform.position = Vector3.Lerp(tempPlayer.transform.position, newPos, i);
        
            }


        }

    }


}
