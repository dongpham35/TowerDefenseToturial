using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text txtRounds;
    public string mainmenu = "MainMenu";

    private void OnEnable()
    {
        txtRounds.text = PlayerStats.round.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
        SceneManager.LoadScene(mainmenu);
    }
}
