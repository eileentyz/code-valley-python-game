using UnityEngine;

public class desktopBGM : MonoBehaviour
{
    public GameObject panel;                    // The panel to monitor
    public GameObject panel1;
    public AudioSource mainBGM;                 // Main background music
    public AudioSource panelMusic;              // Music for the panel
    public GameObject storebutton;

    private bool wasPanelOpen = false;

    void Update()
    {
        if ((panel.activeSelf || panel1.activeSelf) && !wasPanelOpen)
        {
            // Panel just opened
            wasPanelOpen = true;
            if (mainBGM.isPlaying) mainBGM.Pause();
            if (!panelMusic.isPlaying) panelMusic.Play();
            storebutton.SetActive(false);
        }
        else if ((!panel.activeSelf && !panel1.activeSelf) && wasPanelOpen)
        {
            // Panel just closed
            wasPanelOpen = false;
            if (panelMusic.isPlaying) panelMusic.Stop();
            if (!mainBGM.isPlaying) mainBGM.UnPause();
            storebutton.SetActive(true);
        }
    }
}
