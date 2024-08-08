using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menulevel = "MainMenu";
    public string nextLevel = "Level02";
    public int levelToUnLock = 2;
    public SceneFad scenefad;

    public void Continue()
    {
        Debug.Log("You won");
        scenefad.LoadScenebyName(nextLevel);
        if(levelToUnLock > PlayerPrefs.GetInt("levelReached", 1))
            PlayerPrefs.SetInt("levelReached", levelToUnLock);
    }

    public void Menu()
    {
        scenefad.LoadScenebyName(menulevel);
    }
}
