using UnityEngine;

public class ManageButton : MonoBehaviour
{
    public GameObject pythonPanel;
    public GameObject pythonPanel2;
    public GameObject pythonPanel3;
    public GameObject pythonPanel4;
    public GameObject pythonPanel5;
    public GameObject pythonPanel6;
    public GameObject pythonPanel7;
    public GameObject storeButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storeButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(pythonPanel.activeSelf || pythonPanel2.activeSelf || pythonPanel3.activeSelf || pythonPanel4.activeSelf || pythonPanel5.activeSelf || pythonPanel6.activeSelf || pythonPanel7.activeSelf)
        {
            storeButton.SetActive(false);
        }
    }
}
