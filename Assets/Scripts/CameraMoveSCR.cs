using UnityEngine;
using System.Collections;

public class CameraMoveSCR : MonoBehaviour {

    GameObject player;

    Transform startPosition;

    float offestfromInitial;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("player");
        startPosition = transform;
        offestfromInitial = startPosition.transform.position.y - player.transform.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // move up with player
        if (player)
        {
            //      float differenceInPos = transform.position.y - player.transform.position.y;
            //float offestfromInitial = startPosition.transform.position.y - player.transform.position.y;

            Vector3 newPos = new Vector3(startPosition.transform.position.x, player.transform.position.y + offestfromInitial, startPosition.transform.position.z);

            transform.position = Vector3.Lerp(startPosition.transform.position, newPos, 5.0f * Time.deltaTime);
        }
	}
}
