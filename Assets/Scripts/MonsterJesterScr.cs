using UnityEngine;
using System.Collections;

public class MonsterJesterScr : MonoBehaviour {


    public GameObject eyeL;
    public GameObject eyeR;
    GameObject player;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player)
        {
            Vector3 relativePos = player.transform.position - eyeL.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            eyeL.transform.rotation = rotation;

            relativePos = player.transform.position - eyeR.transform.position;
            rotation = Quaternion.LookRotation(relativePos);
            eyeR.transform.rotation = rotation;
        }
	}
}
