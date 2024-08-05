using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Text txtTimerToNextWayenemy;
    public float TimeToNextWayenemy;

    public GameObject EnemyPrefab;
    public Transform SpawnEnemyPoint;

    private float timerWayEnemy = 0;
    private int enemyCount = 0;

    private void Update()
    {
        if(timerWayEnemy <= 0)
        {
            StartCoroutine(SpawnEnemyWay());
            timerWayEnemy = TimeToNextWayenemy;
        }

        timerWayEnemy -= Time.deltaTime;
        timerWayEnemy = Mathf.Clamp(timerWayEnemy, 0 , Mathf.Infinity);
        txtTimerToNextWayenemy.text = string.Format("{0:00.00}", timerWayEnemy);
    }

    IEnumerator SpawnEnemyWay()
    {
        enemyCount++;
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnEnemyPoint.position, EnemyPrefab.transform.rotation);

    }

}
