
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInteraction selectedTool;
    [SerializeField] private float interactionRange = 5f;

    // Reference to UI Manager
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        CheckForToolSelection();
        ActivateTool();
    }

    private void CheckForToolSelection()
    {
        // Example input handling for selecting a tool (button presses)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //ChangeTool(ToolManager.Instance.GetToolByID(1)); // Assuming ToolManager handles tools
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //ChangeTool(ToolManager.Instance.GetToolByID(2));
        }
        // Add more as needed for additional tools
    }

    private void ActivateTool()
    {
        if (selectedTool != null)
        {
            // Here you could check if a resource is within the interaction range
            // and if so, call the ToolSpecificAction
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange);
            foreach (var hitCollider in hitColliders)
            {
                ResourceController resource = hitCollider.GetComponent<ResourceController>();
                if (resource != null)
                {
                    //selectedTool.ToolSpecificAction(resource);
                    break; // Perform action on the first resource found
                }
            }
        }
    }

    public void ChangeTool(PlayerInteraction newTool)
    {
        selectedTool = newTool;
        UpdateToolUI();
    }

    private void UpdateToolUI()
    {
        if (uiManager != null)
        {
            //uiManager.UpdateToolUI(selectedTool);
        }
    }
}
