using UnityEngine;
using System.Collections;

public class PlatformScr : MonoBehaviour {


    GameObject LavaRef;
    float x, y;

	// Use this for initialization
	void Start ()
    {
        LavaRef = GameObject.FindGameObjectWithTag("LAVA");
    }
	
	// Update is called once per frame
	void Update ()
    {
        ScrollingUVs_Layers UV_PosSCR = LavaRef.GetComponent<ScrollingUVs_Layers>();
        Vector2 vec = UV_PosSCR.uvOffset;
        x = vec.x;
        y = vec.y;

        this.GetComponent<Transform>().position.Set(this.GetComponent<Transform>().position.x + x, this.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z); //+= x;



    }
}
