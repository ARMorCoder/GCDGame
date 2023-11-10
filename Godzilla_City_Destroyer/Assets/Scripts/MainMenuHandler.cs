using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void Options(){
        SceneManager.LoadScene("OptionsScene");
    }

    public void Title(){
        Time.timeScale = 1f;
        PauseMenu.gamePause = false;
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
