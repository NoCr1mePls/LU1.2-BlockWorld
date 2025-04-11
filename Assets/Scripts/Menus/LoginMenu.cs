using Helpers;
using Services;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class LoginMenu : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public GameObject loginMenu;
    public GameObject worldSelectMenu;
    /// <summary>
    /// Log in and set the Api token.
    /// </summary>
    public async void Login()
    {
        await ApiCallHelper.Login(email: emailField.text, password: passwordField.text);
        Debug.Log("Logged in");
        SwitchScene();
    }

    private void SwitchScene()
    {
        loginMenu.SetActive(false);
        worldSelectMenu.SetActive(true);
    }
}
