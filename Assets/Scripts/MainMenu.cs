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
    }

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been exited");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
