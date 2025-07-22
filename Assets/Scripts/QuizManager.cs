using System.Collections.Generic;
using System.Diagnostics;
using TMPro;              // For TextMeshPro
using UnityEngine;
using UnityEngine.UI;     // For Button

public class QuizManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text questionText;
    public Button[] optionButtons;
    public TMP_Text feedbackText;
    public TMP_Text coinDisplay;
    public TMP_Text coinDisplay1;

    [Header("Quiz Data")]
    public List<QuizQuestion> allQuestions = new List<QuizQuestion>();

    [Header("Audio")]
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    private AudioSource audioSource;

    private QuizQuestion currentQuestion;
    public int coins;
    public CoinUIManager coinUIManager; // drag this in the Inspector
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (coinUIManager != null)
        {
            coinUIManager.UpdateCoinDisplay();
        }
        else
        {
            UnityEngine.Debug.LogWarning("coinUIManager is not assigned!");
        }

        // Update UI with correct coin value
        coinUIManager.UpdateCoinDisplay();
        coinDisplay.text = "Coins: " + coins;
        coinDisplay1.text = "Coins: " + coins;

        LoadNewQuestion();
    }

    void LoadNewQuestion()
    {
        feedbackText.text = "";
        currentQuestion = allQuestions[UnityEngine.Random.Range(0, allQuestions.Count)];

        questionText.text = currentQuestion.questionText;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            // Reset button color and enable
            optionButtons[i].GetComponent<Image>().color = Color.white;
            optionButtons[i].interactable = true;

            if (i < currentQuestion.options.Length)
            {
                optionButtons[i].gameObject.SetActive(true); // Show button if option exists

                TMP_Text btnText = optionButtons[i].GetComponentInChildren<TMP_Text>();
                btnText.text = currentQuestion.options[i];

                int index = i; // capture index for the listener
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false); // Hide extra buttons if no option
            }
        }
    }

    void CheckAnswer(int selectedIndex)
    {
        // Disable all buttons
        foreach (var btn in optionButtons)
        {
            btn.interactable = false;
        }

        if (selectedIndex == currentQuestion.correctOptionIndex)
        {
            feedbackText.text = "Correct!";
            //coins += 10;

            GameManager.Instance.currentPlayer.coins += 10;
            GameManager.Instance.SavePlayer();
            coinUIManager.UpdateCoinDisplay();

            //coinDisplay.text = "Coins: " + coins;
            //coinDisplay1.text = "Coins: " + coins;

            // Turn correct button green
            optionButtons[selectedIndex].GetComponent<Image>().color = Color.green;

            // Play correct sound
            if (correctSound != null && audioSource != null)
                audioSource.PlayOneShot(correctSound);
        }
        else
        {
            feedbackText.text = "Wrong!";

            // Turn selected button red
            optionButtons[selectedIndex].GetComponent<Image>().color = Color.red;

            // Turn correct button green
            optionButtons[currentQuestion.correctOptionIndex].GetComponent<Image>().color = Color.green;

            // Play incorrect sound
            if (incorrectSound != null && audioSource != null)
                audioSource.PlayOneShot(incorrectSound);
        }

        // Load next question after 2 seconds delay
        Invoke(nameof(LoadNewQuestion), 2f);
    }
}

[System.Serializable]
public class QuizQuestion
{
    public string questionText;
    public string[] options;
    public int correctOptionIndex;
}
