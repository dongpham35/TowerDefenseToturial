using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public Waypoints waypoint;

    public static int Enemyslive = 0;

    public Wave[] waves;

    public Text txtTimerToNextWayenemy;
    public float TimeToNextWayenemy;

    public Transform[] SpawnEnemyPoint;

    private float timerWayEnemy = 0;
    private int waveIndex = 0;


    private void Start()
    {
        GetWay();//Get all way in start level
        waveIndex = 0;
        Enemyslive = 0;
    }
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
            return;
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
        //Setup spawn point for wave
        if(SpawnEnemyPoint.Count() == 1)
        {
            OneSpawnPoint(_enemy);
        }
        else
        {
            TwoSpawnPoint(_enemy);
        }
        
    }


    private void OneSpawnPoint(GameObject _enemy)
    {
        GameObject enemy = Instantiate(_enemy, SpawnEnemyPoint[0].position, _enemy.transform.rotation);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();

        //Set waypoints for enemy
        if (waypoint.getWaysCount() == 1)
            enemyMovement.setWaySelect(Waypoints.firstWay);
        else
        {
            int indexWay = Random.Range(0, 10) % waypoint.getWaysCount();
            switch (indexWay)
            {
                case 0:
                    {
                        enemyMovement.setWaySelect(Waypoints.firstWay);
                        break;
                    }
                case 1:
                    {
                        enemyMovement.setWaySelect(Waypoints.secondWay);
                        break;
                    }
                case 2:
                    {
                        enemyMovement.setWaySelect(Waypoints.thirdWay);
                        break;
                    }
                default:
                    {
                        enemyMovement.setWaySelect(Waypoints.firstWay);
                        break;
                    }
            }
        }
    }
    private void TwoSpawnPoint(GameObject _enemy)
    {
        int indexSpawn = Random.Range(0, 10) % SpawnEnemyPoint.Count(); // random spawnpoint

        //default
        //first spawn point => first way
        //second spawn point => second way
        GameObject enemy = Instantiate(_enemy, SpawnEnemyPoint[indexSpawn].position, _enemy.transform.rotation);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        switch (indexSpawn)
        {
            case 0:
                {
                    enemyMovement.setWaySelect(Waypoints.firstWay);
                    break;
                }
            case 1:
                {
                    enemyMovement.setWaySelect(Waypoints.secondWay);
                    break;
                }
            default:
                {
                    Debug.Log("None!");
                    break;
                }
        }
    }
    //get all ways in this level
    private void GetWay()
    {
        if (waypoint.getWaysCount() > 1)//greatest than 1 way
        {
            for (int i = 0; i < waypoint.getWaysCount(); i++)
            {
                Transform waypoints = waypoint.multiWays[i];
                switch (i)
                {
                    case 0:
                        {
                            //Get the first way
                            Waypoints.firstWay = new Transform[waypoints.childCount];
                            for (int j = 0; j < Waypoints.firstWay.Length; j++)
                            {
                                Waypoints.firstWay[j] = waypoints.GetChild(j);
                            }
                            break;
                        }
                    case 1:
                        {
                            //Get the second way
                            Waypoints.secondWay = new Transform[waypoints.childCount];
                            for (int j = 0; j < Waypoints.secondWay.Length; j++)
                            {
                                Waypoints.secondWay[j] = waypoints.GetChild(j);
                            }
                            break;
                        }
                    case 2:
                        {
                            //Get the third way
                            Waypoints.thirdWay = new Transform[waypoints.childCount];
                            for (int j = 0; j < Waypoints.thirdWay.Length; j++)
                            {
                                Waypoints.thirdWay[j] = waypoints.GetChild(j);
                            }
                            break;
                        }
                    default:
                        {
                            Debug.Log("None");
                            break;
                        }
                }
            }
        }
        else
        {
            Transform waypoints = waypoint.multiWays[0];
            Waypoints.firstWay = new Transform[waypoints.childCount];
            for (int i = 0; i < Waypoints.firstWay.Length; i++)
            {
                Waypoints.firstWay[i] = waypoints.GetChild(i);
            }
            
        }
    }
}
