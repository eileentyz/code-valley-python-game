using UnityEngine;

public class UIPanelSwitcher5 : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public GameObject playerObject; // assign your player GameObject
    public MonoBehaviour playerControlScript; // e.g. your PlayerMovement script

    public void SwitchPanel()
    {
        if (currentPanel != null) currentPanel.SetActive(false);
        if (nextPanel != null) nextPanel.SetActive(true);

        // Disable player movement
        if (playerControlScript != null)
        {
            playerControlScript.enabled = false;
        }
    }

    public void ClosePanelAndEnablePlayer()
    {
        if (nextPanel != null) nextPanel.SetActive(false);

        // Enable player movement again
        if (playerControlScript != null)
        {
            playerControlScript.enabled = true;
        }
    }
}
