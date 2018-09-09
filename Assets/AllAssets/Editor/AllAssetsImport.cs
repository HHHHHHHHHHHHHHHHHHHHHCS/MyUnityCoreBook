using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AllAssetsImport : AssetPostprocessor
{
    public static void OnPostprocessAllAssets(string[] importedAsset, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (var item in importedAsset)
        {
            Debug.Log(item);
        }
    }
}
