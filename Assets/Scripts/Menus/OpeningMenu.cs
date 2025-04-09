using UnityEngine;

public class OpeningMenu : MonoBehaviour
{
    public GameObject openingMenu;

    public void SwitchMenu(GameObject menu)
    {
        menu.SetActive(true);
        CloseOpening();
    }

    public void CloseOpening()
    {
        openingMenu.SetActive(false);
    }
}