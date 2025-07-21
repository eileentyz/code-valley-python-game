using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    public Button registerButton;
    public TextMeshProUGUI messageText;

    void Start()
    {
        loginButton.onClick.AddListener(() =>
        {
            string username = usernameInput.text.Trim();
            string password = passwordInput.text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                messageText.text = "Username and password cannot be empty.";
                return;
            }

            GameManager.Instance.Login(username, password);
        });

        registerButton.onClick.AddListener(() =>
        {
            string username = usernameInput.text.Trim();
            string password = passwordInput.text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                messageText.text = "Username and password cannot be empty.";
                return;
            }

            GameManager.Instance.Register(username, password);
        });
    }
}
