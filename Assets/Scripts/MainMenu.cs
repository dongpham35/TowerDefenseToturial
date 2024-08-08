using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mainlevel = "LevelSelect";
    public SceneFad scenefad;
    public void Play()
    {
        scenefad.LoadScenebyName(mainlevel);
    }

    public void Quit()
    {
        Debug.Log("Exitting...");
        Application.Quit();
    }
}
