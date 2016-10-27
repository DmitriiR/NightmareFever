using UnityEngine;
using System.Collections;

public class TeethController : MonoBehaviour {

    public GameObject topJawRef;
    public GameObject bottomJawRef;

    public Vector3 from = new Vector3(0f, 0f, 135f);
    public Vector3 to = new Vector3(0f, 0f, 225f);
    public float speed = 0.1f;

    // Use this for initialization
    void Start ()
    {
        // try search for default if not attached.
        if (!topJawRef)
        {
            topJawRef = GameObject.FindGameObjectWithTag("TopJaw");
        }
        if (!bottomJawRef)
        {
            bottomJawRef = GameObject.FindGameObjectWithTag("BottomJaw");
        }



    }
	
	// Update is called once per frame
	void Update ()
    {

        float t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);
        topJawRef.transform.position = Vector3.Lerp(from, to, t);

        t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);
        bottomJawRef.transform.eulerAngles = Vector3.Lerp(from, to, t);



    }
}
