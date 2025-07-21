using TMPro;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class LogDisplay : MonoBehaviour
{
    public TMP_Text logText;

    private void OnEnable()
    {
        UnityEngine.Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        UnityEngine.Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logText.text = logString;
    }
}
