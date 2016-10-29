using UnityEngine;
using System.Collections;

public class ScrollingUVs_Layers : MonoBehaviour 
{
    //public int materialIndex = 0;
    public Vector2 uvAnimationRate;// = new Vector2( .50f, 0.0f );
	public string textureName = "_MainTex";
    
	public Vector2 uvOffset = Vector2.zero;
    private GameObject playerRef;
    private GameManager gameManager;
    bool fryPlayer;

    void Start()
    {

        uvAnimationRate.x = 0.0f;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        uvAnimationRate.y = gameManager.GetComponent<GameManager>().LavaFlowSpeed;
        fryPlayer = false;
        playerRef = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        if (fryPlayer)
        {
            playerRef.GetComponent<PlayerControllerScr>().playerLife -= gameManager.GetComponent<GameManager>().LavaDamage;


        }


    }
	void LateUpdate() 
	{
		uvOffset += ( uvAnimationRate * Time.deltaTime );
		if( GetComponent<Renderer>().enabled )
		{
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset( textureName, uvOffset );
		}


	}
    
    
    // COLLISION!!!
    void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag == "Untagged")
            return;

        if (col.gameObject.tag == "player")
        {
            fryPlayer = true;
            col.gameObject.GetComponent<PlayerControllerScr>().playerLife -= GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LavaDamage;
            col.gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = true;
        }
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Untagged")
            return;

        if (col.gameObject.tag == "player")
        {
            fryPlayer = false; 
            //   col.gameObject.GetComponent<PlayerControllerScr>().playerLife -= GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LavaDamage;
            col.gameObject.GetComponentInChildren<ParticleSystem>().enableEmission = false;
        }
    }
}