using UnityEngine;
using UnityEngine.UI;

public class ToolbarController : MonoBehaviour
{
    [System.Serializable]
    public class ToolbarItem
    {
        public Button button;       // The button representing the item
        public GameObject selectedImage; // The image to show when selected
    }

    public ToolbarItem[] toolbarItems; // Array of toolbar items
    public int selectedIndex = 0;    // Index of the currently selected item (-1 for none)

    void Start()
    {
        // Add click listeners to each toolbar button
        for (int i = 0; i < toolbarItems.Length; i++)
        {
            int index = i; // Capture index for the closure
            toolbarItems[i].button.onClick.AddListener(() => OnToolbarItemClicked(index));
        }
    }

    void OnToolbarItemClicked(int index)
    {
        // If the same item is clicked again, deselect it
        if (selectedIndex == index)
        {
            return;
        }
        // Select the newly clicked item
        SetItemSelected(index, true);
        SetItemSelected(selectedIndex, false);
        selectedIndex = index; // Update selected index
    }

    void SetItemSelected(int index, bool isSelected)
    {
        toolbarItems[index].selectedImage.SetActive(isSelected);
    }
}
