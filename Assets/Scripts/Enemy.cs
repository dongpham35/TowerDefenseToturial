using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float StartSpeed = 10f;
    public Image healthbar;

    [HideInInspector]
    public float speed;
    public float StartHealth = 100;
    public int value = 50;
    public GameObject enemyDieEffectPrefab;

    private float Health;

    private void Start()
    {
        speed = StartSpeed;
        Health = StartHealth;
    }

    public void TakeDamage(float amount)
    {
        Health = Mathf.Clamp(Health -= amount, 0 , Health);
        healthbar.fillAmount = Health / StartHealth;
        if(Health == 0)
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
        WaveSpawner.Enemyslive--;
    }

    public void Slow(float pct)
    {
        speed = StartSpeed * (1 - pct);
    }
}
