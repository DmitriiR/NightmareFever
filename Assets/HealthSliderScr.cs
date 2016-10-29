using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthSliderScr : MonoBehaviour {

    // Use this for initialization
    GameObject player;
    PlayerControllerScr playerScr;
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("player");
        playerScr = player.GetComponent<PlayerControllerScr>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player)
        {
            this.GetComponent<Slider>().value = playerScr.playerLife;
            this.GetComponent<Slider>().maxValue = playerScr.playerMaxLife;

            this.GetComponentInChildren<Text>().text = this.GetComponent<Slider>().value.ToString();
        }
    }
}
