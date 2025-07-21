using UnityEngine;

public class BookBGM : MonoBehaviour
{
    public GameObject panel;                    // The panel to monitor
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public AudioSource mainBGM;                 // Main background music
    public AudioSource panelMusic;              // Music for the panel
    public GameObject storebutton;

    private bool wasPanelOpen = false;

    void Update()
    {
        if ((panel.activeSelf || panel1.activeSelf || panel2.activeSelf || panel3.activeSelf || panel4.activeSelf) && !wasPanelOpen)
        {
            // Panel just opened
            wasPanelOpen = true;
            if (mainBGM.isPlaying) mainBGM.Pause();
            if (!panelMusic.isPlaying) panelMusic.Play();
            storebutton.SetActive(false);
        }
        else if ((!panel.activeSelf && !panel1.activeSelf && !panel2.activeSelf && !panel3.activeSelf && !panel4.activeSelf) && wasPanelOpen)
        {
            // Panel just closed
            wasPanelOpen = false;
            if (panelMusic.isPlaying) panelMusic.Stop();
            if (!mainBGM.isPlaying) mainBGM.UnPause();
            storebutton.SetActive(true);
        }
    }
}
