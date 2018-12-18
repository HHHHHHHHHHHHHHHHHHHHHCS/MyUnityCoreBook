using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogListener : MonoBehaviour
{
    public Text logText;
    public Button btn;

    private void Awake()
    {
        btn.onClick.AddListener(() =>
        {
            Debug.Log("TestLog");
            Debug.LogError("Test Error");
            List<int> a = null;
            a.Add(0);
        });

        Application.logMessageReceived += LogMessageReceivedFunc;
    }

    private void OnDestroy()
    {
        Application.logMessageReceived -= LogMessageReceivedFunc;
    }

    public void LogMessageReceivedFunc(string logValue,string stackTrace
        ,LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            Time.timeScale = 0f;
            logText.text += "<color=red>" + logValue + "\n" + stackTrace + "</color>";
        }
        else
        {
            logText.text = logValue + "\n" + stackTrace;
        }
    }
}
