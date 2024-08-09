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

    private bool isDie = false;
    private float Health;

    private void Start()
    {
        speed = StartSpeed;
        Health = StartHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDie)
            return;
        Health -= amount;
        healthbar.fillAmount = Health / StartHealth;
        if(Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDie = true;
        PlayerStats.money += value;
        GameObject dieeffect = Instantiate(enemyDieEffectPrefab, transform.position, Quaternion.identity);
        WaveSpawner.Enemyslive -=1;
        Destroy(dieeffect, 2f);
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = StartSpeed * (1 - pct);
    }
}
