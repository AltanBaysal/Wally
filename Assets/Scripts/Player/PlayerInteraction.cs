
using System.Resources;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{ 

    [SerializeField] private int selectedTool;
    [SerializeField] private float interactionRange = 5f;
    [SerializeField] private ToolbarController toolbarController;
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private Planting planting;
    [SerializeField] private ResourceManager resourceManager;

    // Reference to UI Manager
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        int selectedIndex = toolbarController.selectedIndex;
        switch (selectedIndex)
        {
            case 0:
                Debug.Log("Using Watering Can.");
                // Sulama Animasyonu Çalıştır
                break;
            case 1:
                Debug.Log("Using Sickle.");
                // Add your logic here
                break;
            case 2:
                Debug.Log("Using Gun.");
                playerCombat.ShootBullet();
                break;
            case 3:
                Debug.Log("Using Bamboo Seed.");
                planting.PlantSeed("bamboo");
                break;
            case 4:
                Debug.Log("Using Olive Seed.");
                planting.PlantSeed("olive");
                break;
            case 5:
                Debug.Log("Using Pomegranate Seed.");
                planting.PlantSeed("pomegranate");
                break;
            case 6:
                Debug.Log("Using Bay Seed.");
                planting.PlantSeed("bay");
                break;
        }
    }
}
