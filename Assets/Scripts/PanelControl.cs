using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public GameObject panel; // The UI panel to show/hide
    public MonoBehaviour playerMovementScript; // Drag your PlayerMovement script here

    public void OpenPanel()
    {
        panel.SetActive(true);
        if (playerMovementScript != null)
            playerMovementScript.enabled = false;
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        if (playerMovementScript != null)
            playerMovementScript.enabled = true;
    }
}
