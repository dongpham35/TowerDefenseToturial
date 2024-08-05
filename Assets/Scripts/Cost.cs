using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cost : MonoBehaviour
{
    public Text txtCost;
    void Update()
    {
        txtCost.text = "$"+PlayerStats.money.ToString();
    }
}
