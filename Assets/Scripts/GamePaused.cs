using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    public GameObject ui;
    public string mainmenu = "MainMenu";
    public SceneFad scenefad;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            toggle();
        }
    }

    public void toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        toggle();
        scenefad.LoadScenebyName(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        toggle();
        Debug.Log("Go to menu");
        scenefad.LoadScenebyName(mainmenu);
    }
}
