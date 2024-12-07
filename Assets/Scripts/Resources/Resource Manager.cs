using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<string, int> resources = new Dictionary<string, int>();

    // Reference to ResourceUIManager
    public ResourceUI resourceUIManager;

    private void Start()
    {
        // Initialize resources
        resources["bamboo"] = 5;
        resources["olive"] = 5;
        resources["pomegranate"] = 5;
        resources["bay"] = 5;

        // Find and assign the ResourceUIManager in the scene
        resourceUIManager.UpdateResourceUI("bamboo", resources["bamboo"]);
        resourceUIManager.UpdateResourceUI("olive", resources["olive"]);
        resourceUIManager.UpdateResourceUI("pomegranate", resources["pomegranate"]);
        resourceUIManager.UpdateResourceUI("bay", resources["bay"]);
        if (resourceUIManager == null)
        {
            Debug.LogError("ResourceUIManager not found in the scene!");
        }
    }

    // Method to update resource amount
    public void UpdateResource(string resourceName, int amount)
    {
        if (!resources.ContainsKey(resourceName))
        {
            Debug.LogError($"Resource {resourceName} does not exist!");
            return;
        }

        resources[resourceName] += amount;

        // Update UI via ResourceUIManager
        resourceUIManager?.UpdateResourceUI(resourceName, resources[resourceName]);
    }

    // Method to get resource amount
    public int GetResourceAmount(string resourceName)
    {
        if (resources.ContainsKey(resourceName))
        {
            return resources[resourceName];
        }
        Debug.LogError($"Resource {resourceName} does not exist!");
        return 0;
    }
}
