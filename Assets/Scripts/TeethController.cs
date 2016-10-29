using UnityEngine;
using System.Collections;

public class TeethController : MonoBehaviour {

    public GameObject topJawRef;
    public GameObject bottomJawRef;

    Vector3 from; 
    Vector3 to; 
    public float speed = 0.1f;

    // Use this for initialization
    IEnumerator Start ()
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

        from = topJawRef.transform.position;
        to = new Vector3(topJawRef.transform.position.x, topJawRef.transform.position.y + 5, topJawRef.transform.position.z);
        Vector3 fromBotom = bottomJawRef.transform.position;
        Vector3 toBottom = new Vector3(bottomJawRef.transform.position.x, bottomJawRef.transform.position.y - 5, bottomJawRef.transform.position.z);

        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(topJawRef, from, to, 1.0f, bottomJawRef, fromBotom, toBottom));
            yield return StartCoroutine(MoveObject(topJawRef, to, from, 0.1f, bottomJawRef, toBottom, fromBotom));
            //yield return StartCoroutine(MoveObject(topJawRef, to, from, 1.0f));

           // yield return StartCoroutine(MoveObject(bottomJawRef, fromBotom, toBottom, 1.0f));
          //  yield return StartCoroutine(MoveObject(bottomJawRef, toBottom, fromBotom, 1.0f));

        }

    }

    IEnumerator MoveObject(GameObject object1, Vector3 startPos, Vector3 endPos, float time, GameObject object2, Vector3 startPos2, Vector3 endPos2)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            object1.transform.position = Vector3.Lerp(startPos, endPos, i);

            object2.transform.position = Vector3.Lerp(startPos2, endPos2, i);

            yield return null;
        }
    }

    // Update is called once per frame
    void Update ()
    {

      //  float t = Mathf.PingPong( 10.0f , 5.0f);
        //  topJawRef.transform.position = Vector3.Lerp(from, to, t);
        
          //  t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);
          //  bottomJawRef.transform.eulerAngles = Vector3.Lerp(from, to, t);

        //  Vector3 newPos = new Vector3(topJawRef.transform.position.x, topJawRef.transform.position.y + t, transform.position.z);
       // topJawRef.transform.position = newPos;




       

     //   float    min = topJawRef.transform.position.x;
     //   float    max = topJawRef.transform.position.x + 3;



      //  topJawRef.transform.position = new Vector3(topJawRef.transform.position.x, topJawRef.transform.position.y + Mathf.PingPong(Time.time * 2, max - min) + min, topJawRef.transform.position.z);

       

    }
}
