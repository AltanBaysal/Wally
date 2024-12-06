
using UnityEngine;

public enum TargetChoice
{
    Player,
    Structures
}

public class EnemyBehaviorAI : MonoBehaviour
{
    [SerializeField]
    private float aggressionLevel = 1.0f;
    [SerializeField]
    private int retreatThreshold = 20;
    [SerializeField]
    private TargetChoice targetChoice = TargetChoice.Player;

    private int currentHealth = 100;
    private bool isRetreating = false;

    void Update()
    {
        DecideNextAction();
    }

    public void DecideNextAction()
    {
        if (currentHealth <= retreatThreshold)
        {
            SwitchToRetreatBehavior();
        }
        else if (IsPlayerNearby())
        {
            AggressiveBehavior();
        }
    }

    private void SwitchToRetreatBehavior()
    {
        if (!isRetreating)
        {
            isRetreating = true;
            // Implement retreat behavior logic, e.g., change movement speed, flee direction, etc.
            Debug.Log("Switching to retreat behavior");
        }
    }

    private void AggressiveBehavior()
    {
        if (aggressionLevel > 0)
        {
            // Implement aggressive behavior logic, e.g., increase attack rate, deal more damage, etc.
            Debug.Log("Executing aggressive behavior");
            EnhanceStats();
            TriggerCombatEvents();
        }
    }

    private bool IsPlayerNearby()
    {
        // Placeholder for detecting player proximity logic
        return Vector3.Distance(transform.position, FindObjectOfType<PlayerMovement>().transform.position) < 10f;
    }

    private void EnhanceStats()
    {
        // Logic to enhance enemy stats
    }

    private void TriggerCombatEvents()
    {
        // Logic to trigger combat-related events
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Current Health: {currentHealth}");
    }
}
