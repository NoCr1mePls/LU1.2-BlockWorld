using Helpers;
using TMPro;
using UnityEngine;

public class LoginMenu : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public GameObject loginMenu;
    public GameObject worldSelectMenu;
    public GameObject errorText;
    /// <summary>
    /// Log in and set the Api token.
    /// </summary>
    public async void Login()
    {
        try
        {
        await ApiCallHelper.Login(email: emailField.text, password: passwordField.text);
        Debug.Log("Logged in");
        SwitchScene();
        }
        catch
        {
            errorText.SetActive(true);
            Debug.Log("Unsuccesfull login");
        }
    }

    private void SwitchScene()
    {
        loginMenu.SetActive(false);
        worldSelectMenu.SetActive(true);
    }
}
