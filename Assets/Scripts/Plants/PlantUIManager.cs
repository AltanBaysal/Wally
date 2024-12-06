
using UnityEngine;
using UnityEngine.UI;

public class PlantUIManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject tooltip;

    public void UpdateHealthBar(int currentHealth)
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / 100f; // Assuming max health of 100
        }
    }

    public void ShowTooltip(string info)
    {
        if (tooltip != null)
        {
            tooltip.SetActive(true);
            tooltip.GetComponentInChildren<Text>().text = info; // Assuming tooltip has a Text component for displaying info
        }
    }

    public void HideTooltip()
    {
        if (tooltip != null)
        {
            tooltip.SetActive(false);
        }
    }
}
