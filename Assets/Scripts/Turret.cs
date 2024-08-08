using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;

    [Header("Use bullet(Default)")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;


    [Header("Use laser")]
    public float damagePct = 30f;
    public bool userlaser = false;
    public LineRenderer linerenderer;
    public float slow = .5f;
    public ParticleSystem laserBeamerImpactEffectPrefab;
    public Light lightImpact;

    [Header("Unity setup fields")]
    public string nameTag = "Enemy";
    public Transform PartToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }


    private void UpdateTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(nameTag);
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach(GameObject go in enemys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, go.transform.position);
            if(distanceToEnemy < minDistance)
            {
                nearestEnemy = go;
                minDistance = distanceToEnemy;
            }
        }

        if (nearestEnemy != null && minDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            if (userlaser)
            {
                if (linerenderer.enabled)
                {
                    linerenderer.enabled = false;
                    laserBeamerImpactEffectPrefab.Stop();
                    lightImpact.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if (userlaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0)
            {
                Shooting();
                fireCountDown = fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }
        
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.position - PartToRotate.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void Laser()
    {
        targetEnemy.TakeDamage(damagePct * Time.deltaTime);
        targetEnemy.Slow(slow);
        if (!linerenderer.enabled)
        {
            linerenderer.enabled = true;
            laserBeamerImpactEffectPrefab.Play();
            lightImpact.enabled = true;
        }
        
        linerenderer.SetPosition(0, firePoint.position);
        linerenderer.SetPosition(1, target.position);
        Vector3 dir = firePoint.position - target.position;
        laserBeamerImpactEffectPrefab.transform.position = target.position + dir.normalized;
        laserBeamerImpactEffectPrefab.transform.rotation = Quaternion.LookRotation(dir);
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Shooting()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
        Bullet bulletScript = bulletClone.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }
}
