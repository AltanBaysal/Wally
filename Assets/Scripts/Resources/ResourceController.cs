
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private int currentAmount = 0;
    [SerializeField] private string resourceType;
    [SerializeField] private bool isCollectable = true;

    private void Awake()
    {
        InitializeResourceAttributes();
    }

    private void InitializeResourceAttributes()
    {
        // You can set default values or randomize resources here if required.
        currentAmount = 0;
        resourceType = "DefaultType"; // Set an initial type, modify as needed.
        isCollectable = true; // Resource is collectible by default.
        ChangeResourceAppearance();
    }

    public void CollectResource(int amount)
    {
        if (isCollectable)
        {
            currentAmount += amount;
            UpdateResourceCount();
            ChangeResourceAppearance();
        }
    }

    private void UpdateResourceCount()
    {   /*
        PlayerUI playerUI = FindObjectOfType<PlayerUI>();
        if (playerUI != null)
        {
            playerUI.UpdateResourceDisplay(resourceType, currentAmount);
        }
        else
        {
            Debug.LogWarning("PlayerUI not found! Unable to update resource count.");
        }*/
    }

    private void ChangeResourceAppearance()
    {
        if (currentAmount <= 0)
        {
            isCollectable = false;
        }

        // Assume AnimationController is a separate script handling animations.
        AnimationController animationController = GetComponent<AnimationController>();
        if (animationController != null)
        {
            //animationController.PlayResourceAnimation(currentAmount, isCollectable);
        }
    }
}
