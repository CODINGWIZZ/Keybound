using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Toggle toggle;
    public GameObject settingsMenu;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        settingsMenu.SetActive(false);
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene("SampleScene");
    }

    public void ToggleDyslexiaFont()
    {
        toggle.isOn = !toggle.isOn;
        GameManager.Instance.globalControlls.dylcticFont = !GameManager.Instance.globalControlls.dylcticFont;
    }

    public void QuitGame()
    {
        Debug.Log("Game has been exited");
        Application.Quit();
    }
}
