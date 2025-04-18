using Dtos;
using Helpers;
using System;
using TMPro;
using UnityEngine;

public class NewWorldMenu : MonoBehaviour
{
    public TMP_InputField worldNameInput;
    public GameObject newWorldMenu;
    public GameObject mainMenu;
    public GameObject worldSelectMenu;
    public async void Confirm()
    {
        string newName = worldNameInput.text.ToUpper();
        if (newName.Length > 0)
        {
            foreach (Environment2DDto existingEnvironments in EnvironmentHolder.Environments)
            {
                if (existingEnvironments.Name.ToUpper().Equals(newName))
                {
                    return;
                }
            }
            Environment2DDto newEnvironment = new Environment2DDto
            {
                Id = Guid.NewGuid(),
                Name = worldNameInput.text,
                UserId = ""
            };
            EnvironmentHolder.currentEnvironment = newEnvironment;
            await ApiCallHelper.StoreNewEnvironment(newEnvironment);
            SwitchToMain();
        }
        else
            Debug.Log("Name too short");
    }

    public void Cancel()
    {
        newWorldMenu.SetActive(false);
        worldSelectMenu.SetActive(true);
    }

    public void SwitchToMain()
    {
        newWorldMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
