using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject camera;
    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
