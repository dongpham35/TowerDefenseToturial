using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform[] waySelect;
    private Transform target;
    private int currentWaypointIndex = 0;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    public void Update()
    {
        if (target == null) return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemy.speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            changeToNextWayPoint(waySelect);
        }

        enemy.speed = enemy.StartSpeed;
    }

    private void changeToNextWayPoint(Transform[] waypoints)
    {
        if (currentWaypointIndex >= waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        currentWaypointIndex++;
        target = waypoints[currentWaypointIndex];
    }
    private void EndPath()
    {
        PlayerStats.lives -= 1;
        WaveSpawner.Enemyslive -= 1;
        Destroy(gameObject);
    }

    public void setWaySelect(Transform[] _wayselect)
    {
        waySelect = new Transform[_wayselect.Length];
        waySelect = _wayselect;
        target = waySelect[currentWaypointIndex];
    }
}
