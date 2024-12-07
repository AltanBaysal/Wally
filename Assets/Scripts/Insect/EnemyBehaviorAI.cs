using Unity.VisualScripting;
using UnityEngine;

public enum TargetChoice
{
    Plant,
    Tower,
    Both
}

public class EnemyBehaviorAI : MonoBehaviour
{
    [SerializeField]
    private TargetChoice targetChoice = TargetChoice.Plant;
    public GameObject currentTarget;

    [SerializeField]
    private float attackRange = 2.0f;
    [SerializeField]
    private float attackDamage = 10.0f;
    [SerializeField] private float movementSpeed = 3f;

    [SerializeField]
    private float attackCooldown = 1.0f; // Cooldown time in seconds
    private float lastAttackTime = 0f; // Track the time of the last attack

    void Update()
    {
        DecideNextAction();
    }

    public void DecideNextAction()
    {
        if (currentTarget == null || !IsTargetAlive(currentTarget))
        {
            FindNewTarget();
        }
        else if (IsTargetInRange())
        {
            if (Time.time - lastAttackTime >= attackCooldown) // Check if cooldown has passed
            {
                AttackTarget();
            }
        }
        else
        {
            MoveTowardsTarget();
        }
    }

    private bool IsTargetAlive(GameObject target)
    {
        // Check if the target is alive or destroyed
        return target != null;
    }

    private void FindNewTarget()
    {
        GameObject[] potentialTargets;

        if (targetChoice == TargetChoice.Plant)
        {
            potentialTargets = GameObject.FindGameObjectsWithTag("Plant");
        }
        else if (targetChoice == TargetChoice.Both)
        {
            potentialTargets = GameObject.FindGameObjectsWithTag("Plant");
            potentialTargets.AddRange(GameObject.FindGameObjectsWithTag("Tower"));
        }
        else
        {
            potentialTargets = GameObject.FindGameObjectsWithTag("Tower");
        }

        float closestDistance = float.MaxValue;

        foreach (var target in potentialTargets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentTarget = target;
            }
        }

        if (currentTarget != null)
        {
            Debug.Log($"New target acquired: {currentTarget.name}");
        }
        else
        {
            Debug.Log("No valid targets found");
        }
    }

    private bool IsTargetInRange()
    {
        if (currentTarget == null) return false;
        return Vector3.Distance(transform.position, currentTarget.transform.position) <= attackRange;
    }

    private void AttackTarget()
    {
        Debug.Log($"Attacking {currentTarget.name}");
        currentTarget.GetComponent<HealthManager>()?.TakeDamage(attackDamage);
        lastAttackTime = Time.time; // Update the last attack time
    }

    private void MoveTowardsTarget()
    {
        if (currentTarget == null) return;

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, Time.deltaTime * movementSpeed);
        Debug.Log($"Moving towards {currentTarget.name}");
    }
}
