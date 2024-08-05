using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 15f;
    public int Health = 100;
    public int value = 50;
    public GameObject enemyDieEffectPrefab;

    private static int currentHealth;

    private Transform target;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[currentWaypointIndex];
        currentHealth = Health;
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
            Damage();
            return;
        }
        currentWaypointIndex++;
        target = Waypoints.waypoints[currentWaypointIndex];
    }

    private void Damage()
    {
        PlayerStats.lives -= 1;
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth -= damage, 0 , Health);
        if(currentHealth == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        PlayerStats.money += value;
        GameObject dieeffect = Instantiate(enemyDieEffectPrefab, transform.position, Quaternion.identity);
        Destroy(dieeffect, 5f);
        Destroy(gameObject);
    }
}
