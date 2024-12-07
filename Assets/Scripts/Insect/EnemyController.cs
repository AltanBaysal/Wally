
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour,HealthManager
{
    [SerializeField] private float health = 100;

    public void TakeDamage(float amount)
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
        //SoundManager.Instance.PlaySound("EnemyDeath");
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
