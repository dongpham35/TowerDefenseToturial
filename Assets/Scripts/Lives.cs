using UnityEngine.UI;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public Text txtLives;

    // Update is called once per frame
    void Update()
    {
        txtLives.text = PlayerStats.lives.ToString() + " LIVES";
    }
}
