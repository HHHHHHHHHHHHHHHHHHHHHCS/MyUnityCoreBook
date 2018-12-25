using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEditorState 
{
    void StartEditor();
    void PreRun();
    void RunGame();
    void WillEndRun();
}
