
using UnityEngine;

public class FenceManager : MonoBehaviour
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private bool isConstructed = false;
    [SerializeField] private Vector2 gridPosition;
    [SerializeField] private int health = 100;

    public void ConstructFence(Vector2 position)
    {
        if (CheckResources())
        {
            gridPosition = position;
            isConstructed = true;
            UpdateGrid();
            Debug.Log("Fence constructed at: " + gridPosition);
        }
        else
        {
            Debug.Log("Not enough resources to construct the fence.");
        }
    }

    public void DismantleFence()
    {
        if (isConstructed)
        {
            ReclaimResources();
            isConstructed = false;
            UpdateGrid();
            Debug.Log("Fence dismantled.");
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Fence took damage: " + damageAmount + ", current health: " + health);
        CheckDestruction();
    }

    private void CheckDestruction()
    {
        if (health <= 0)
        {
            PlayDestructionAnimation();
            isActive = false;
            UpdateGrid();
            Debug.Log("Fence destroyed.");
        }
    }

    private bool CheckResources()
    {
        // Implementation for resource checking
        return true; // Placeholder for resource check
    }

    private void ReclaimResources()
    {
        // Implementation for reclaiming resources
    }

    private void UpdateGrid()
    {
        // Implementation for updating the grid state
    }

    private void PlayDestructionAnimation()
    {
        // Implementation for playing destruction animation
    }
}
