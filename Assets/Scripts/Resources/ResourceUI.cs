
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private Text resourceCountText;
    [SerializeField] private List<Image> resourceIcons;

    private Dictionary<string, int> resourceCounts = new Dictionary<string, int>();

    public void UpdateResourceDisplay(int amount, string resourceName)
    {
        if (!resourceCounts.ContainsKey(resourceName))
        {
            resourceCounts[resourceName] = 0;
        }
        
        resourceCounts[resourceName] += amount;
        resourceCountText.text = resourceCounts[resourceName].ToString();
    }

    public void ShowResourceCollectionAnimation()
    {
        foreach (var icon in resourceIcons)
        {
            // Example implementation for an animation effect (you can use your preferred method)
            StartCoroutine(BounceIcon(icon));
        }
    }

    private System.Collections.IEnumerator BounceIcon(Image icon)
    {
        Vector3 originalPosition = icon.transform.localPosition;
        Vector3 targetPosition = originalPosition + new Vector3(0, 10, 0);
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            icon.transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            icon.transform.localPosition = Vector3.Lerp(targetPosition, originalPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        icon.transform.localPosition = originalPosition; // Reset to original position
    }
}
