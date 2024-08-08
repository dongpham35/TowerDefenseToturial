using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameManager gameManager;

    public static int Enemyslive = 0;

    public Wave[] waves;

    public Text txtTimerToNextWayenemy;
    public float TimeToNextWayenemy;

    public Transform SpawnEnemyPoint;

    private float timerWayEnemy = 0;
    private int waveIndex = 0;

    private void Update()
    {
        if (Enemyslive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            this.enabled = false;
            gameManager.WinLevel();
        }

        if (timerWayEnemy <= 0)
        {
            StartCoroutine(SpawnEnemyWay());
            timerWayEnemy = TimeToNextWayenemy;
            return;
        }

        timerWayEnemy -= Time.deltaTime;
        timerWayEnemy = Mathf.Clamp(timerWayEnemy, 0, Mathf.Infinity);
        txtTimerToNextWayenemy.text = string.Format("{0:00.00}", timerWayEnemy);
    }

    IEnumerator SpawnEnemyWay()
    {
        Wave wave = waves[waveIndex];
        PlayerStats.round ++;
        Enemyslive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    private void SpawnEnemy(GameObject _enemy)
    {
        Instantiate(_enemy, SpawnEnemyPoint.position, _enemy.transform.rotation);
    }

}
