using System.Diagnostics;
using System.IO;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public static class SaveSystem1
{
    private static string folderPath = UnityEngine.Application.persistentDataPath + "/players/";

    public static void SavePlayer(PlayerData1 player)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string json = JsonUtility.ToJson(player, true);
        string fullPath = folderPath + player.username + ".json";
        File.WriteAllText(fullPath, json);
    }

    public static PlayerData1 LoadPlayer(string username)
    {
        string fullPath = folderPath + username + ".json";

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            PlayerData1 player = JsonUtility.FromJson<PlayerData1>(json);
            return player;
        }
        else
        {
            return null;
        }
    }
}
