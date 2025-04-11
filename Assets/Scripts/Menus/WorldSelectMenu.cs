using Dtos;
using Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelectMenu : MonoBehaviour
{
    public Environment2DDto[] environments;
    public TMP_Text[] buttonTexts;
    public GameObject worldSelectMenu;
    public GameObject mainMenu;
    async void Start()
    {
        environments = await ApiCallHelper.GetEnvironments();
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
    }
}
