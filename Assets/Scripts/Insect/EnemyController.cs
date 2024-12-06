
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType { Caterpillar, Grasshopper, Tarantula }

    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 10;
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private Transform target;
    [SerializeField] private float attackRange = 2f;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movementSpeed;

        // Assign target based on game context (for demonstration, we just find the player)
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
            CheckForCombat();
        }
    }

    private void MoveTowardsTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void CheckForCombat()
    {
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            TakeDamage(damage);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayDeathAnimation();
        SoundManager.Instance.PlaySound("EnemyDeath");
        Destroy(gameObject);
    }

    private void PlayDeathAnimation()
    {
        // Trigger death animation logic here (requires an Animator component)
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }
}
