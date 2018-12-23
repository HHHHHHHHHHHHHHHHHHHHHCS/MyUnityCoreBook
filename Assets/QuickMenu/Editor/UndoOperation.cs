using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public static class UndoOperation
{
    [MenuItem("MyMenu/DelDisableObject")]
    private static void DelObject()
    {
        var objs = Selection.gameObjects;
        foreach(var item in objs)
        {
            for (int i= item.transform.childCount-1;i>=0;i--)
            {
                GameObject go = item.transform.GetChild(i).gameObject;
                if(!go.activeInHierarchy)
                {
                    Undo.DestroyObjectImmediate(go);
                }
            }
        }
    }

    [MenuItem("MyMenu/TransformChange")]
    private static void TransformChange()
    {
        var objs = Selection.gameObjects;
        float lineY = 0;
        if(objs.Length>0)
        {
            lineY = objs[0].transform.position.y;
        }

        foreach(var go in objs)
        {
            var trans = go.transform;
            Undo.RecordObject(trans, "Change Transform");
            trans.position = new Vector3(trans.position.x, lineY, trans.position.z);
        }
    }
}
