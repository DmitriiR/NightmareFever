using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// RUNS THE ACTUAL GAME

public class GameManager : MonoBehaviour {

    // Use this for initialization
    float gameTime = 0.0f;
    int gameTimeInt = 0;
    GameObject timerTextRef;
    

  //  public float LavaFlowSpeed;
    public float PlatformSpeed;
    public float LavaDamage;
	void Start ()
    {
        gameTime = 0.0f;
        timerTextRef = GameObject.FindGameObjectWithTag("TimerText");
    }
	
	// Update is called once per frame
	void Update () {
        // timer
        gameTime += Time.deltaTime;
        gameTimeInt = (int)gameTime;
        timerTextRef.GetComponent<Text>().text = gameTimeInt.ToString();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
