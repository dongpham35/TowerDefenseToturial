using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundSurival : MonoBehaviour
{
    public Text txtRoundSurival;


    private void OnEnable()
    {
        StartCoroutine(AnimatorRound());
    }

    IEnumerator AnimatorRound()
    {
        txtRoundSurival.text = "0";
        int level = 0;
        yield return new WaitForSeconds(.3f);
        while(level < PlayerStats.round)
        {
            level++;
            txtRoundSurival.text  = level.ToString();
            yield return new WaitForSeconds(.1f);
        }
    }



}
