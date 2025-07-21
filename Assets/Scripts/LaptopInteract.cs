using UnityEngine;
using UnityEngine.UI;

public class LaptopInteract : MonoBehaviour
{
    public GameObject interactionPrompt; // E.g. a Text or Panel that says "Press E"
    public GameObject pythonPanel;       // The panel that opens when player interacts
    public AudioSource audioSource;

    private bool isPlayerNear = false;

    private void Start()
    {
        interactionPrompt.SetActive(false);
        pythonPanel.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            pythonPanel.SetActive(true);
            interactionPrompt.SetActive(false);
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
