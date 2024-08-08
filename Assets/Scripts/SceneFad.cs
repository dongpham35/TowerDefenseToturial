using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFad : MonoBehaviour
{
    public Image ui;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadIn());
    }

    public void LoadScenebyName(string _nameScene)
    {
        StartCoroutine(FadOut(_nameScene));
    }
    IEnumerator FadIn()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            ui.color = new Color(0, 0 , 0 , a);
            yield return 0;
        }
    }

    IEnumerator FadOut(string _nameScene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            ui.color = new Color(0, 0, 0, a);
            yield return 0;
        }
        SceneManager.LoadScene(_nameScene);
    }
}
