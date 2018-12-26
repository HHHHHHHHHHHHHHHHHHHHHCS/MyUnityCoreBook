using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public static class ResCheck
{
    public static void WalkDir(string path, string extRule, Action<string> callback)
    {
        DirectoryInfo baseDir = new DirectoryInfo(path);

        if (baseDir == null)
        {
            Debug.Log("input null dir:" + path);
        }
        else
        {
            if (baseDir.Attributes == FileAttributes.Directory)
            {
                foreach (var dir in baseDir.GetDirectories())
                {
                    WalkDir(dir.FullName, extRule, callback);
                }
                FileInfo[] files = baseDir.GetFiles(extRule);
                foreach (var file in files)
                {
                    callback(ToAssetPath(file.FullName));
                }
            }
        }
    }

    private static string ToAssetPath(string fullPath)
    {
        string[] splited2 = fullPath.Split(new string[] { "Assets" },
            System.StringSplitOptions.RemoveEmptyEntries);
        string nameShort = "Assets" + splited2[1];
        return nameShort;
    }

    [MenuItem("MyMenu/WalkDir")]
    private static void MyWalk()
    {
        var objs = Selection.objects;
        if (objs != null && objs.Length > 0)
        {
            foreach (var eachDir in objs)
            {
                WalkDir(AssetDatabase.GetAssetPath(eachDir), "*.prefab", (path) =>
                  {
                      var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                      var texts = prefab.GetComponentsInChildren<Text>();
                      foreach (var t in texts)
                      {
                          t.color = new Color(1, 0, 0, 1);
                      }
                      AssetDatabase.SaveAssets();
                  });
            }
        }
    }

    [MenuItem("MyMenu/FindMaterial")]
    private static void MyMat()
    {
        var mats = Resources.FindObjectsOfTypeAll<Material>();
        foreach(var mat in mats)
        {
            var shader = ((Material)mat).shader;
            if(shader.name.Contains("Standard"))
            {
                Debug.Log("Use Standard,Path is:" + AssetDatabase.GetAssetPath(mat), mat);
            }
        }
    }
}
