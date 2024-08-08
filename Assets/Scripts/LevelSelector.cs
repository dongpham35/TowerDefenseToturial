using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFad scenefad;

    public void Select(string name)
    {
        scenefad.LoadScenebyName(name);
    }
}
