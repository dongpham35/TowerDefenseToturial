using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 15f;

    private Transform target;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[currentWaypointIndex];
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            changeToNextWayPoint();
        }
    }

    private void changeToNextWayPoint()
    {
        if (currentWaypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        currentWaypointIndex++;
        target = Waypoints.waypoints[currentWaypointIndex];
    }
}
