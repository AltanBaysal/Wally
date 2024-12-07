
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private UIManager uiManager;

    private void Start()
    {
        currentHealth = maxHealth;
        uiManager = FindObjectOfType<UIManager>();
        UpdateHealthUI();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthUI();
        TriggerHitAnimation();

        if (currentHealth <= 0)
        {
            //gameManager.GameOver();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (uiManager != null)
        {
            //uiManager.UpdateHealthDisplay(currentHealth, maxHealth);
        }
    }

    private void TriggerHitAnimation()
    {
        // Trigger animation logic here
        Debug.Log("Player hit, trigger hit animation.");
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            //gameManager.GameOver();
        }
    }
}
