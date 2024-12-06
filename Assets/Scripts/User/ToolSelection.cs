
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSelection : MonoBehaviour
{
    [SerializeField] private List<string> toolList;
    [SerializeField] private Image selectedToolIcon;
    private int selectedToolIndex;
    private ResourceManager resourceManager;
    private UIManager uiManager;

    private void Awake()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        DisplayToolSelection();
        UpdateToolAvailability();
    }

    public void DisplayToolSelection()
    {
        // Code to display available tools in the UI can be implemented here.
        // This can include updating a UI panel with buttons for each tool in the toolList.
    }

    public void ChangeSelectedTool(int index)
    {
        if (index >= 0 && index < toolList.Count)
        {
            selectedToolIndex = index;
            UpdateSelectedToolIcon();
            uiManager.SelectTool(toolList[selectedToolIndex]);
        }
    }

    private void UpdateSelectedToolIcon()
    {
        // Code to update the selectedToolIcon based on the currently selected tool index.
        // This can include loading the icon image assigned to the selected tool.
    }

    public void UpdateToolAvailability()
    {
        for (int i = 0; i < toolList.Count; i++)
        {
            if (resourceManager.CanUseTool(toolList[i]))
            {
                // Enable the tool in the UI
            }
            else
            {
                // Disable the tool in the UI
            }
        }
    }
}
