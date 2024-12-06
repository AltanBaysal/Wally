
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    public Vector2 mouseClickPos;

    private void Update()
    {
        HandleMouseClick();
        ShowHoverFeedback();
    }

    private void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouseClickPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Assuming the UIManager has a method to handle interactions
                ///UIManager.Instance.HandleUIInteraction(hit.collider.gameObject);
            }
        }
    }

    private void ShowHoverFeedback()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        /*var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("Interactive"))
            {
                // Implement visual feedback such as highlighting
                // For example, change the color of the UI element
                var graphic = result.gameObject.GetComponent<Graphic>();
                if (graphic != null)
                {
                    graphic.color = Color.yellow; // Hover color
                }
            }
        }*/
    }
}
