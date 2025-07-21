using UnityEngine;

public class UIClosePanel : MonoBehaviour
{
    public GameObject currentPanel;
    public MonoBehaviour playerControlScript; // e.g. your PlayerMovement script
    public AudioSource musicBGM;
    public AudioSource sleepBGM;
    public AudioSource alarm;

    public void ClosePanel()
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);
            sleepBGM.Stop();
            alarm.Play();
            musicBGM.Play();

        if (playerControlScript != null)
            playerControlScript.enabled = true;
    }
}
