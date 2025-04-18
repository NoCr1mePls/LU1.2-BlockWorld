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
    public GameObject worldDeleteMenu;
    public GameObject[] deleteButtons;
    async void Start()
    {
        DefaultValuesSet();
        environments = await ApiCallHelper.GetEnvironments();
        EnvironmentHolder.Environments = environments;
        if (environments.Length <= 5)
        {
            for (int i = 0; i < environments.Length; i++)
            {
                buttonTexts[i].SetText($"Load world {i + 1}: {environments[i].Name}");
                deleteButtons[i].SetActive(true);
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
            mainMenu.GetComponent<Menu>().Load();
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

    public async void OnEnable()
    {
        DefaultValuesSet();
        environments = await ApiCallHelper.GetEnvironments();
        EnvironmentHolder.Environments = environments;
        if (environments.Length <= 5)
        {
            for (int i = 0; i < environments.Length; i++)
            {
                buttonTexts[i].SetText($"Load world {i + 1}: {environments[i].Name}");
                deleteButtons[i].SetActive(true);
            }
        }
    }

    public void DeleWorld(int index)
    {
        if (index < environments.Length)
        {
            EnvironmentHolder.currentEnvironment = environments[index];
            worldSelectMenu.SetActive(false);
            worldDeleteMenu.SetActive(true);
        }
    }

    public void DefaultValuesSet()
    {
        foreach (GameObject gameObject in deleteButtons)
        {
            gameObject.SetActive(false);
        }
        for (int i = 0; i < buttonTexts.Length; i++)
        {
            buttonTexts[i].SetText($"Load world {i + 1}: empty");
        }
    }
}
