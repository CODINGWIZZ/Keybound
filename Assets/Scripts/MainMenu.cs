using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Debug.Log("Game has been exited");
        Application.Quit();
    }
}
