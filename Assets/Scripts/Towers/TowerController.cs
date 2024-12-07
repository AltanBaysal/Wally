
using System.Linq;
using UnityEngine;

public enum TowerType { SingleTarget, AoE }

public class TowerController : MonoBehaviour, HealthManager
{
    [SerializeField] private float health = 100;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private TowerType towerType;
    public GameObject bulletPrefab;

    private float attackTimer = 0f;


    void Update()
    {
        attackTimer += Time.deltaTime;
        CheckForEnemies();

    }

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            DestroyTower();
        }
    }

    private void CheckForEnemies()
    {
        GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = float.MaxValue;
        GameObject currentTarget = null;

        foreach (var target in potentialTargets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            // Check if the target is within the tower's range
            if (distance < closestDistance && distance <= attackRange)
            {
                closestDistance = distance;
                currentTarget = target;
            }
        }

        if (currentTarget != null && attackTimer >= attackCooldown)
        {
            EnemyController enemy = currentTarget.GetComponent<EnemyController>();
            AttackEnemy(enemy);
            attackTimer = 0f; // Reset the attack timer after attacking
        }
        else if (currentTarget == null)
        {
            Debug.Log("No valid targets found within range");
        }
    }
        
    private void AttackEnemy(EnemyController target)
    {
        // Create the bullet at the shoot point
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Assign the target to the bullet's script
            TowerProjectile bulletController = bullet.GetComponent<TowerProjectile>();
            if (bulletController != null)
            {
                bulletController.SetTarget(target);
            }
        }
        PlayAttackSound();
        // Trigger attack animation if Animation component is available
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
        attackTimer = 0f;
    }

    public void UpgradeTower()
    {
        health += 20; // Example of health increase on upgrade
    }

    private void DestroyTower()
    {
        Destroy(gameObject);
    }

    private void PlayAttackSound()
    {
        // Assuming a SoundManager exists with a Play method
        //SoundManager.Instance.Play("TowerAttack");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
