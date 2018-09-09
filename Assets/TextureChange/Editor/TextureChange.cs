using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TextureChange : AssetPostprocessor
{
    void OnPostprocessTexture(Texture2D t)
    {
        try
        {
            TextureImporter importer = assetImporter as TextureImporter;
            Debug.Log(importer.assetPath);

            importer.mipmapEnabled = false;
            importer.textureType = TextureImporterType.Sprite;
            EditorUtility.SetDirty(importer);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
