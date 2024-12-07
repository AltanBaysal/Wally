using System.Resources;
using UnityEngine;

public class Planting : MonoBehaviour
{
    public GameObject player; // Reference to the Player GameObject
    public GameObject bambooPrefab;
    public GameObject olivePrefab;
    public GameObject pomegranatePrefab;
    public GameObject bayPrefab;

    private ResourceManager resourceManager; // Reference to the ResourceManager

    private void Start()
    {
        // Find the ResourceManager in the scene
        resourceManager = FindObjectOfType<ResourceManager>();
        if (resourceManager == null)
        {
            Debug.LogError("ResourceManager not found in the scene!");
        }
    }

    // Method to instantiate a plant based on its name
    public void PlantSeed(string plantName)
    {
        if (resourceManager == null) return; // Ensure ResourceManager is available

        Vector3 playerPosition = player.transform.position; // Get player's current position

        switch (plantName.ToLower())
        {
            case "bamboo":
                if (resourceManager.GetResourceAmount("bamboo") > 0)
                {
                    Instantiate(bambooPrefab, playerPosition, Quaternion.identity);
                    resourceManager.UpdateResource("bamboo",-1);
                    Debug.Log("Planted Bamboo at player's location.");
                }
                else
                {
                    Debug.LogWarning("Not enough Bamboo resources to plant!");
                }
                break;
            case "olive":
                if (resourceManager.GetResourceAmount("olive") > 0)
                {
                    Instantiate(olivePrefab, playerPosition, Quaternion.identity);
                    resourceManager.UpdateResource("olive", -1);
                    Debug.Log("Planted Olive at player's location.");
                }
                else
                {
                    Debug.LogWarning("Not enough Olive resources to plant!");
                }
                break;
            case "pomegranate":
                if (resourceManager.GetResourceAmount("pomegranate") > 0)
                {
                    Instantiate(pomegranatePrefab, playerPosition, Quaternion.identity);
                    resourceManager.UpdateResource("pomegranate", -1);
                    Debug.Log("Planted Pomegranate at player's location.");
                }
                else
                {
                    Debug.LogWarning("Not enough Pomegranate resources to plant!");
                }
                break;
            case "bay":
                if (resourceManager.GetResourceAmount("bay") > 0)
                {
                    Instantiate(bayPrefab, playerPosition, Quaternion.identity);
                    resourceManager.UpdateResource("bay", -1);
                    Debug.Log("Planted Bay at player's location.");
                }
                else
                {
                    Debug.LogWarning("Not enough Bay resources to plant!");
                }
                break;
            default:
                Debug.LogWarning($"Plant {plantName} is not recognized!");
                break;
        }
    }
}
