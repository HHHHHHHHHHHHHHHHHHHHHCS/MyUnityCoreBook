using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FileMove : UnityEditor.AssetModificationProcessor
{
    private static string prefabPath = "Assets/FileMove/TestPrefab.prefab";

    public static AssetMoveResult _OnWillMoveAsset(string oldPath,string newPath)
    {
        AssetMoveResult result = AssetMoveResult.DidNotMove;
        if(oldPath==prefabPath)
        {
            result = AssetMoveResult.FailedMove;
            EditorUtility.DisplayDialog("Error", "Don't Move Me!","OK!!!");
        }
        return result;
    }
}
