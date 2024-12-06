
using UnityEngine;

public enum TowerType { SingleTarget, AoE }

public class TowerController : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 25;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private TowerType towerType;
    [SerializeField] private bool isActive = true;

    private float attackTimer = 0f;

    void Start()
    {
        isActive = true;
    }

    void Update()
    {
        if (isActive)
        {
            attackTimer += Time.deltaTime;
            CheckForEnemies();
        }
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            DestroyTower();
        }
    }

    private void CheckForEnemies()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var enemyCollider in hitEnemies)
        {
            EnemyController enemy = enemyCollider.GetComponent<EnemyController>();
            if (enemy != null && attackTimer >= attackCooldown)
            {
                AttackEnemy(enemy);
                break; // Attack one enemy at a time
            }
        }
    }

    private void AttackEnemy(EnemyController target)
    {
        target.TakeDamage(damage);
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
        damage += 10; // Example of damage increase on upgrade
    }

    private void DestroyTower()
    {
        isActive = false;
        // Optional: Play destruction animation or effects here
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
