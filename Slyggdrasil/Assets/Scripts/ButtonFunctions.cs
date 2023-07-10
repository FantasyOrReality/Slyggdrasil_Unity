using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void PlaySinglePlayer()
    {
        SceneManager.LoadScene("1pLevel1");

    }
    public void PlayMultiPlayer()
    {
        SceneManager.LoadScene("2pLevel1");

    }

    public void SelectMode()
    {
        SceneManager.LoadScene("ModeSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");

    }

}
