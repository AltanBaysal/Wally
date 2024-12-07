using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<string, int> resources = new Dictionary<string, int>();

    // Reference to ResourceUIManager
    private ResourceUI resourceUIManager;

    private void Start()
    {
        // Initialize resources
        resources["Bambu"] = 0;
        resources["Olive"] = 0;
        resources["Pomegranate"] = 0;
        resources["Bay"] = 0;

        // Find and assign the ResourceUIManager in the scene
        resourceUIManager = FindObjectOfType<ResourceUI>();
        resourceUIManager.UpdateResourceUI("Bambu", 0);
        resourceUIManager.UpdateResourceUI("Olive", 0);
        resourceUIManager.UpdateResourceUI("Pomegranate", 0);
        resourceUIManager.UpdateResourceUI("Bay", 0);
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
