using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    private EnemyController target;
    public float speed = 10f;
    public int damage = 10; // Damage dealt by the projectile

    public void SetTarget(EnemyController target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target != null)
        {
            // Move the projectile towards the target
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Check if the projectile hits the target
            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
            {
                HealthManager healthManager = target.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(damage); // Call TakeDamage on HealthManager
                }
                Destroy(gameObject); // Destroy the projectile
            }
        }
        else
        {
            Destroy(gameObject); // Destroy the projectile if no target
        }
    }
}
    