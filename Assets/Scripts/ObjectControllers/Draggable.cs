using UnityEngine;

/// <summary>
/// A GameObject that can get dragged around upon clicking on it
/// </summary>
public class Draggable : MonoBehaviour
{
    public bool isDragging = false;
    public Menu menuController;

    /// <summary>
    /// Updates the location of the GameObject.
    /// </summary>
    void Update()
    {
        if (isDragging)
        {
            Vector3 position = Helper.GetMousePosition2D();
            this.gameObject.transform.position = position;
        }
    }

    /// <summary>
    /// Toggles between isDragging = true and false and notifies the menu controller.
    /// </summary>
    private void OnMouseUpAsButton()
    {
        isDragging = !isDragging;
        menuController.UpdateMenuState();
    }
}
