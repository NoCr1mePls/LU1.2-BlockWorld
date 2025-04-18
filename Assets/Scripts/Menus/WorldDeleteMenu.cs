using Helpers;
using UnityEngine;

public class WorldDeleteMenu : MonoBehaviour
{
    public GameObject worldDeletemenu;
    public GameObject worldSelectMenu;
   public async void Confirm()
    {
        await ApiCallHelper.DeleteEnvironment();
        worldDeletemenu.SetActive(false);
        worldSelectMenu.SetActive(true);
    }
    public void Cancel()
    {
        worldDeletemenu.SetActive(false);
        worldSelectMenu.SetActive(true);
    }
}
