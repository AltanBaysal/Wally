using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    public TextMeshProUGUI bambuText;
    public TextMeshProUGUI oliveText;
    public TextMeshProUGUI pomegranateText;
    public TextMeshProUGUI bayText;

    public void UpdateResourceUI(string resourceName, int newAmount)
    {
        switch (resourceName)
        {
            case "bamboo":
                bambuText.text = $"{newAmount}";
                break;
            case "olive":
                oliveText.text = $"{newAmount}";
                break;
            case "pomegranate":
                pomegranateText.text = $"{newAmount}";
                break;
            case "bay":
                bayText.text = $"{newAmount}";
                break;
            default:
                Debug.LogError($"Resource {resourceName} does not have a UI element!");
                break;
        }
    }
}
