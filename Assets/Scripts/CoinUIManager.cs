using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinUIManager : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text coinText1;

    void Start()
    {
        UpdateCoinDisplay();
    }

    public void UpdateCoinDisplay()
    {
        if (GameManager.Instance != null && GameManager.Instance.currentPlayer != null)
        {
            int coins = GameManager.Instance.currentPlayer.coins;
            coinText.text = "Coins: " + coins;
            coinText1.text = coinText.text;
        }
        else
        {
            coinText.text = "Coins: 0";
            coinText1.text = "Coins: 0";
        }
    }
}
