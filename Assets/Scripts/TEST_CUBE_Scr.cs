using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TEST_CUBE_Scr : MonoBehaviour {

    public int int1;

    Material mat;

    GameObject button2;
    Button theButtonComponet;


    void Start ()
    {
        // mat.color = Color.green;

        mat = this.GetComponent<MeshRenderer>().material;
        if (mat == true)
            Debug.Log("Found the material just fine");


        button2 = GameObject.FindGameObjectWithTag("Button2");
        if (button2)
            Debug.Log("button found");
	}

    public void ChangeToRed()
    {
        Debug.Log("Changing to Red");

       // Color col = Vector3(10.0f,10.0f, 10.0f);

        if (mat)
            mat.color = Color.red;
        if(button2)
        button2.GetComponentInChildren<Text>().text = "READY";
        theButtonComponet =  button2.GetComponent<Button>();
        theButtonComponet.onClick.AddListener(ChangeMeFunc);
    }


    void ChangeMeFunc()
    {

        mat.color = Color.green;

    }





	
	void Update ()
    {

      

    }
}
