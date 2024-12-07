
using System.Resources;
using UnityEngine;
using static PlantBehavior;

public class PlayerInteraction : MonoBehaviour
{ 

    [SerializeField] private int selectedTool;
    [SerializeField] private float interactionRange = 5f;
    [SerializeField] private ToolbarController toolbarController;
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private Planting planting;
    [SerializeField] public ResourceManager resourceManager;

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
                useSickle();
                break;
            case 2:
                Debug.Log("Using Gun.");
                playerCombat.Shoot();
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

    private void useSickle()
    {
        // Check if there are any colliders in range when the sickle is used
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f); // You can adjust the radius as needed
        
        foreach (Collider2D collider in colliders)
        {
            // If the collider is a plant, proceed with the action

            if (collider.CompareTag("Plant"))
            {
                PlantBehavior plant = collider.GetComponent<PlantBehavior>();
                if (plant.growthStage == GrowthStage.Mature)
                {
                    // Get the plant type from the object's name
                    string plantType = plant.plantName;

                    // Update the resource manager with the plant type
                    resourceManager.UpdateResource(plantType, 5);

                    // Optionally destroy the plant after collection
                    Destroy(collider.gameObject);
                }
            }
        }
    }
}
