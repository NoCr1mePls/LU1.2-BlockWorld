using System.Text.RegularExpressions;
using UnityEngine;
using System.Security.Cryptography;
using System.Linq;
using System.Text;

public static class Helper
{

    /// <summary>
    /// Gets the mouse position in 2D (z-axis = 0)
    /// </summary>
    /// <returns>The position of the mouse relative to the screen.</returns>
    public static Vector3 GetMousePosition2D()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        return position;
    }

    /// <summary>
    /// Checks if the given email is a valid email, meaning no spaces and ending with a domain name.
    /// </summary>
    /// <param name="email">The email to check</param>
    /// <returns>True if valid</returns>
    public static bool ValidateEmail(string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Validates if the password is not only numeric or alphanumeric. Password must also be atleast 10 characters long
    /// </summary>
    /// <param name="password"></param>
    /// <returns>True if valid</returns>
    public static bool ValidatePassword(string password)
    {
        if (new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{10,})$").IsMatch(password))
        {
            return true;
        }
        return false;
    }
}
