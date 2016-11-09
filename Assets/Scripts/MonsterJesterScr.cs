using UnityEngine;
using System.Collections;

public class MonsterJesterScr : MonoBehaviour {


    public GameObject eyeL;
    public GameObject eyeR;
    GameObject player;
    GameObject gameManager;
    Vector3 startPos;
    bool stopMove = false;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        /*
        float time = 3.0f;
        float moveForwardDist = 10.0f;
        Vector3 NewPos = new Vector3(transform.position.x, transform.position.y  + moveForwardDist  , transform.position.z);
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f && !stopMove)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, NewPos, i);
         }
        */
        


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

    void OnCollisionEnter(Collision col)
    {
        // we have collided with the player, move back
        if (col.gameObject.tag == "player")
        {
            stopMove = true;

        }

    }

}
