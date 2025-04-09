using Helpers;
using Services;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class LoginMenu : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;

    /// <summary>
    /// Log in and set the Api token.
    /// </summary>
    public async void Login()
    {
        await ApiCallHelper.Login(email: emailField.text, password: passwordField.text);
        Debug.Log($"Login request sent.");
    }
}
