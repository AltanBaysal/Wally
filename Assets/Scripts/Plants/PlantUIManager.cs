
using UnityEngine;
using UnityEngine.UI;

public class PlantUIManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public void UpdateHealthBar(int currentHealth)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / 100f; // Assuming max health of 100
        }
    }

}
