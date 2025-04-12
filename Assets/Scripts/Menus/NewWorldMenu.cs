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
   public void Confirm()
    {
        string newName = worldNameInput.text.ToUpper();
        foreach(Environment2DDto existingEnvironments in EnvironmentHolder.Environments)
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
        ApiCallHelper.StoreNewEnvironment(newEnvironment);
        SwitchToMain();
    }

    public void SwitchToMain()
    {
        mainMenu.SetActive(true);
        newWorldMenu.SetActive(false);
    }
}
