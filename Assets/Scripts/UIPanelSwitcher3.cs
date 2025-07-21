using UnityEngine;

public class UIPanelSwitcher3 : MonoBehaviour
{
    public GameObject currentPanel;
    public MonoBehaviour playerControlScript; // e.g. your PlayerMovement script

    public void ClosePanel()
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (playerControlScript != null)
            playerControlScript.enabled = true;
    }
}
