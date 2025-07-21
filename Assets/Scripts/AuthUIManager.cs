using System.Diagnostics;
using TMPro;
using UnityEngine;

public class AuthUIManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    public void OnRegisterButtonClick()
    {
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            GameManager.Instance.Register(username, password);
        }
        else
        {
            UnityEngine.Debug.Log("Username or password is empty.");
        }
    }

    public void OnLoginButtonClick()
    {
        string username = usernameInput.text.Trim();
        string password = passwordInput.text;

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            GameManager.Instance.Login(username, password);
        }
        else
        {
            UnityEngine.Debug.Log("Username or password is empty.");
        }
    }
}
