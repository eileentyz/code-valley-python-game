using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    public GameObject nextPanel;
    public MonoBehaviour playerControlScript; // e.g. PlayerMovement
    public AudioSource audiopop;

    public Button buyButton;       // Drag your Buy Button here
    public int catPrice = 50;      // How much the cat costs
    public QuizManager quizManager; // Reference to the QuizManager

    public GameObject catObject; // Drag your cat GameObject here
    public GameObject buybutton;
    public GameObject purchased;

    public AudioSource buySound;
    public CoinUIManager coinUIManager;

    private bool hasBoughtCat = false;

    void Start()
    {
        if (GameManager.Instance == null)
        {
            UnityEngine.Debug.LogError("GameManager.Instance is NULL");
            return;
        }

        if (GameManager.Instance.currentPlayer == null)
        {
            UnityEngine.Debug.LogError("GameManager.Instance.currentPlayer is NULL");
            return;
        }

        hasBoughtCat = GameManager.Instance.currentPlayer.hasBoughtCat;

        if (hasBoughtCat)
        {
            buyButton.interactable = false;
            buybutton.SetActive(false);
            purchased.SetActive(true);
            if (catObject != null)
                catObject.SetActive(true);
        }
        else
        {
            if (catObject != null)
                catObject.SetActive(false);
        }
        quizManager.coins = GameManager.Instance.currentPlayer.coins;

        UpdateBuyButton();
    }

    public void Update()
    {
        quizManager.coins = GameManager.Instance.currentPlayer.coins;

        UpdateBuyButton();
    }



    public void TogglePanel()
    {
        if (nextPanel == null || playerControlScript == null) return;

        bool isCurrentlyOpen = nextPanel.activeSelf;
        nextPanel.SetActive(!isCurrentlyOpen);
        audiopop.Play();

        playerControlScript.enabled = isCurrentlyOpen;

        // Update Buy button when panel opens
        if (!isCurrentlyOpen)
        {
            UpdateBuyButton();
        }
    }

    public void UpdateBuyButton()
    {
        if (buyButton == null || quizManager == null) return;

        if (hasBoughtCat || quizManager.coins < catPrice)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }

    public void BuyCat()
    {
        if (hasBoughtCat || quizManager.coins < catPrice) return;

        // Deduct coins
        quizManager.coins -= catPrice;
        GameManager.Instance.currentPlayer.coins = quizManager.coins;

        // Save the cat purchase
        hasBoughtCat = true;
        GameManager.Instance.currentPlayer.hasBoughtCat = true; // ✅ Save this to disk
        GameManager.Instance.SavePlayer();                      // ✅ Save it for next time

        // Update coin UI
        coinUIManager.UpdateCoinDisplay();
        quizManager.coinDisplay.text = "Coins: " + quizManager.coins;
        quizManager.coinDisplay1.text = "Coins: " + quizManager.coins;

        // Disable button and show purchase
        buyButton.interactable = false;
        buySound.Play();
        buybutton.SetActive(false);
        purchased.SetActive(true);

        // Show the cat
        if (catObject != null)
            catObject.SetActive(true);

        UnityEngine.Debug.Log("Cat bought and saved!");
    }


}
