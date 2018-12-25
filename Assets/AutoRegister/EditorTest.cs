using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTest : IEditorState
{
    public void PreRun()
    {
        Debug.Log("PreRun");
    }

    public void RunGame()
    {
        Debug.Log("RunGame");
    }

    public void StartEditor()
    {
        Debug.Log("StartEditor");
    }

    public void WillEndRun()
    {
        Debug.Log("WillEndRun");
    }
}
