using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFad scenefad;
    public Button[] buttons;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);
            if(i + 1 > levelReached)
                buttons[i].interactable = false;
        }
    }

    public void Select(string name)
    {
        scenefad.LoadScenebyName(name);
    }
}
