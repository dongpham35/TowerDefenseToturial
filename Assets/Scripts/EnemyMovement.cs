using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int currentWaypointIndex = 0;
    private Enemy enemy;

    private void Start()
    {
        target = Waypoints.waypoints[currentWaypointIndex];
        enemy = GetComponent<Enemy>();
    }
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemy.speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            changeToNextWayPoint();
        }

        enemy.speed = enemy.StartSpeed;
    }

    private void changeToNextWayPoint()
    {
        if (currentWaypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        currentWaypointIndex++;
        target = Waypoints.waypoints[currentWaypointIndex];
    }
    private void EndPath()
    {
        PlayerStats.lives -= 1;
        Destroy(gameObject);
        WaveSpawner.Enemyslive--;
    }
}
