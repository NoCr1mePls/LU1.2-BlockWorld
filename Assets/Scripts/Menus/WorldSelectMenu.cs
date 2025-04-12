using Dtos;
using Helpers;
using TMPro;
using UnityEngine;

public class WorldSelectMenu : MonoBehaviour
{
    public static Environment2DDto[] environments;
    public TMP_Text[] buttonTexts;
    public GameObject worldSelectMenu;
    public GameObject mainMenu;
    public GameObject newWorldMenu;

    async void Start()
    {
        environments = await ApiCallHelper.GetEnvironments();
        EnvironmentHolder.Environments = environments;
        if (environments.Length <= 5)
        {
            for (int i = 0; i < environments.Length; i++)
            {
                buttonTexts[i].SetText($"Load world {i + 1}: {environments[i].Name}");
            }
        }
    }

    public void SelectWorld(int index)
    {
        if (index < environments.Length)
        {
            EnvironmentHolder.currentEnvironment = environments[index];
            worldSelectMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            SwitchToNewWorldMenu();
        }
    }

    public void SwitchToNewWorldMenu()
    {
        newWorldMenu.SetActive(true);
        worldSelectMenu.SetActive(false);
    }
}
