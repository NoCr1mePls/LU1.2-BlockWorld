using Helpers;
using Services;
using TMPro;
using UnityEngine;

public class RegisterMenu : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_InputField validatePassword;
    public GameObject registerMenu;
    public GameObject worldSelectMenu;
    /// <summary>
    /// Log in and set the Api token.
    /// </summary>
    public async void Register()
    {
        if (passwordField.text.Equals(validatePassword.text))
        {
            await ApiCallHelper.Register(email: emailField.text, password: passwordField.text);
            await ApiCallHelper.Login(email: emailField.text, password: passwordField.text);
            SwitchScene();
        }
        else Debug.Log("Your passwords dont match");
    }

    private void SwitchScene()
    {
        registerMenu.SetActive(false);
        worldSelectMenu.SetActive(true);
    }
}
