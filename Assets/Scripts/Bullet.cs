using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float SpeedBullet;
    public GameObject bulletEffectPrefab;
    public float explossionRadius = 0f;
    public int dame = 50;

    public void SetTarget(Transform _target)
    {
        if(_target!= null)
        {
            target = _target;
        }
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = SpeedBullet * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject bulleteffect = Instantiate(bulletEffectPrefab, transform.position, transform.rotation);
        Destroy(bulleteffect, 2f);
        if(explossionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    private void Damage(Transform _target)
    {
        EnemyController enemy = _target.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(dame);
        }
    }
     
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explossionRadius);
        foreach(Collider collider in colliders)
        {
           if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explossionRadius);
    }
}
