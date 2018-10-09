using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMTest : MonoBehaviour
{
    string inputText = "";

    private void OnGUI()
    {
        inputText = GUILayout.TextField(inputText, GUILayout.Height(30)
            , GUILayout.Width(200));

        if(GUILayout.Button("Submit",GUILayout.Width(100),GUILayout.Height(50)))
        {
            Debug.Log(GMModule.Instance.Call(inputText));
        }
    }
}
