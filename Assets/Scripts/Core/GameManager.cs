using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData1 currentPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Register(string username, string password)
    {
        if (SaveSystem1.LoadPlayer(username) != null)
        {
            UnityEngine.Debug.Log("Username already exists");
            return;
        }

        PlayerData1 newPlayer = new PlayerData1(username, password);
        newPlayer.isLoggedIn = true;
        currentPlayer = newPlayer;
        SavePlayer();
        UnityEngine.Debug.Log("Registered and logged in");
        SceneManager.LoadScene("LivingRoomScene"); // Change to your scene
    }

    public void Login(string username, string password)
    {
        PlayerData1 loadedPlayer = SaveSystem1.LoadPlayer(username);

        if (loadedPlayer == null)
        {
            UnityEngine.Debug.Log("No such user");
            return;
        }

        if (loadedPlayer.password != password)
        {
            UnityEngine.Debug.Log("Wrong password");
            return;
        }

        //if (loadedPlayer.isLoggedIn)
        //{
            //UnityEngine.Debug.Log("Already logged in on another session.");
            //return;
        //}

        loadedPlayer.isLoggedIn = true;
        currentPlayer = loadedPlayer;
        SavePlayer();
        UnityEngine.Debug.Log("Login successful");
        SceneManager.LoadScene("LivingRoomScene"); // Change to your scene
    }

    public void SavePlayer()
    {
        if (currentPlayer != null)
        {
            SaveSystem1.SavePlayer(currentPlayer);
            UnityEngine.Debug.Log("Player data saved");
        }
    }

    private void OnApplicationQuit()
    {
        if (currentPlayer != null)
        {
            currentPlayer.isLoggedIn = false;
            SavePlayer();
            UnityEngine.Debug.Log("Player logged out on quit");
        }
    }
}
