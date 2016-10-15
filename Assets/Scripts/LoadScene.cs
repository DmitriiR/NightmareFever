using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    //Variables
    public GameObject loadingImage;



    // takes the index of the scene from the build settings
    public void LoadLevel(int _level)
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(_level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
