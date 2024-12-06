
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Combat Settings")]
    [SerializeField] private float weaponRange = 5f;
    [SerializeField] private float attackCooldown = 1f;
    private PlayerCombat currentWeapon;
    private float lastAttackTime;

    private void Update()
    {
        // Check for mouse input to initiate attacks against enemies within range.
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        // Trigger the attack animation
        if (currentWeapon != null)
        {
            //currentWeapon.TriggerAttackAnimation();
            DamageEnemiesInRange();
            lastAttackTime = Time.time;
        }
    }

    private void DamageEnemiesInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, weaponRange);
        foreach (Collider hitCollider in hitColliders)
        {
            EnemyController enemy = hitCollider.GetComponent<EnemyController>();
            if (enemy != null)
            {
                //enemy.DealDamage(currentWeapon.GetDamage());
            }
        }
    }

    public void EquipWeapon(PlayerCombat newWeapon)
    {
        currentWeapon = newWeapon;
        //ChangeAnimationState(currentWeapon.GetAnimationState());
    }

    private void ChangeAnimationState(string newState)
    {
        // Code to change the animation state, assuming you have an Animator component
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play(newState);
        }
    }
}
