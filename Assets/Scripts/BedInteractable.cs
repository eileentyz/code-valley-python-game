using UnityEngine;
using UnityEngine.UI;

public class BedInteractable : MonoBehaviour
{
    public GameObject interactionPrompt; // E.g. a Text or Panel that says "Press E"
    public GameObject pythonPanel;       // The panel that opens when player interacts
    public AudioSource audioSource;
    public GameObject sleepingPic;
    public AudioSource musicBGM;
    public AudioSource sleepBGM;
    public GameObject playerObject; // assign your player GameObject
    public MonoBehaviour playerControlScript; // e.g. your PlayerMovement script
    public GameObject storeButton; // assign your player GameObject

    private bool isPlayerNear = false;

    private void Start()
    {
        interactionPrompt.SetActive(false);
        pythonPanel.SetActive(false);
        sleepingPic.SetActive(false);
        storeButton.SetActive(true);
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            pythonPanel.SetActive(true);
            sleepingPic.SetActive(true);
            interactionPrompt.SetActive(false);
            musicBGM.Stop();
            sleepBGM.Play();
            storeButton.SetActive(false);

            // Disable player movement
            if (playerControlScript != null)
            {
                playerControlScript.enabled = false;
            }
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
            interactionPrompt.SetActive(false);
        }
    }
}
