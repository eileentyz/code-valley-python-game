using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorInteractable : MonoBehaviour
{
    public GameObject interactionPrompt; // E.g. a Text or Panel that says "Press E"
    public AudioSource audioSource;

    private bool isPlayerNear = false;

    private void Start()
    {
        interactionPrompt.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            interactionPrompt.SetActive(false);

            if (GameManager.Instance.currentPlayer != null)
            {
                SaveSystem1.SavePlayer(GameManager.Instance.currentPlayer);
            }
            SceneManager.LoadScene("MainPage");
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            interactionPrompt.SetActive(true);
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactionPrompt != null)
            {
                interactionPrompt.SetActive(false);
            }
        }
    }
}
