using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AnimImport : AssetPostprocessor
{
    void OnPostprocessModel(GameObject obj)
    {
        try
        {
            //这里延迟一帧等资源刷新
            EditorApplication.delayCall += RemoveFBX;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    void RemoveFBX()
    {
        EditorApplication.delayCall -= RemoveFBX;

        ModelImporter importer = assetImporter as ModelImporter;
        Debug.Log(importer.assetPath);
        if (importer.assetPath.Contains("fbx")
            && !importer.assetPath.Contains("Models"))
        {
            var assets = AssetDatabase.LoadAllAssetsAtPath(importer.assetPath);
            foreach (var clipObj in assets)
            {
                if (clipObj is AnimationClip&&!clipObj.name.Contains("__preview__"))
                {
                    string outputPath = Path.GetDirectoryName(importer.assetPath)
                        + Path.DirectorySeparatorChar + clipObj.name + ".anim";
                    var currentAsset = AssetDatabase.LoadAssetAtPath<AnimationClip>(outputPath);
                    if (currentAsset != null)
                    {
                        EditorUtility.CopySerialized(clipObj, currentAsset);
                        EditorUtility.SetDirty(currentAsset);
                    }
                    else
                    {
                        var newAnim = new AnimationClip();
                        EditorUtility.CopySerialized(clipObj, newAnim);
                        AssetDatabase.CreateAsset(newAnim, outputPath);
                    }
                }
            }
        }


        //AssetDatabase.DeleteAsset(assetImporter.assetPath);

    }
}
