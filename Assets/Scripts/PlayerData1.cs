[System.Serializable]
public class PlayerData1
{
    public string username;
    public string password; // ✅ this must be saved

    public int coins;
    public bool hasBoughtCat;
    public bool isLoggedIn;

    public PlayerData1(string username, string password)
    {
        this.username = username;
        this.password = password;
        this.coins = 0;
        this.hasBoughtCat = false;
        this.isLoggedIn = false;
    }
}
