using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// RUNS THE ACTUAL GAME

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
