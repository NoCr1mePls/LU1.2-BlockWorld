using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A GameObject that can get dragged around upon clicking on it
/// </summary>
public class Draggable : MonoBehaviour
{
    public bool isDragging = false;
    public GameObject menu;

    /// <summary>
    /// Updates the location of the GameObject. If the GameObject is dragging, the menu get's hidden.
    /// </summary>
    void Update()
    {
        if (isDragging)
        {
            Vector3 position = Helper.GetMousePosition2D();
            this.gameObject.transform.position = position;
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            }
        }
        else
        {
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
            }
        }
    }
    
    /// <summary>
    /// Toggles between isDragging = true and false.
    /// </summary>
    private void OnMouseUpAsButton()
    {
        isDragging = !isDragging;
    }
}
