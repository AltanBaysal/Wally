
using UnityEngine;
using UnityEngine.UI;

public class FenceUIManager : MonoBehaviour
{
    [SerializeField] private int resourceCost;
    [SerializeField] private GameObject feedbackOverlay;
    [SerializeField] private string insufficientResourcesMessage;
    [SerializeField] private Text resourceDisplayText; // Assuming there's a UI Text element to display resources

    private void Awake()
    {
        feedbackOverlay.SetActive(false);
    }

    public void DisplayFeedback(Vector2 position)
    {
        feedbackOverlay.transform.position = position;
        feedbackOverlay.SetActive(true);
    }

    public void ShowInsufficientResourcesMessage()
    {
        Debug.Log(insufficientResourcesMessage); // Displaying message in the console for debugging
    }

    public void UpdateResourceDisplay(int currentResources)
    {
        resourceDisplayText.text = $"Resources: {currentResources}";
    }
}
