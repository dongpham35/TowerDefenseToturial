using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverUI;
    public GameObject completeLevelUI;

    public static bool gameover;

    private void Start()
    {
        gameover = false;
    }

    void Update()
    {
        if (gameover)
        {
            return;
        }

        if(PlayerStats.lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameover = true;
        gameoverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameover = true;
        completeLevelUI.SetActive(true);
    }
}
