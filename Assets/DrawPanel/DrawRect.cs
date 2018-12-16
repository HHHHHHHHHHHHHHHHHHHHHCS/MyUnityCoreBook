using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRect : RangeShower
{
    #region Public Attr
    public float  width ,height;
    #endregion


    public override void UpdateMesh()
    {
        base.UpdateMesh();

        Vector2 uvCenter = new Vector2(0.5f, 0.5f);
        vertices = new Vector3[4];
        triangles = new int[6];
        uvs = new Vector2[4];
        float _width = width / 2;
        float _height = height / 2;
        vertices[0] = new Vector3(-_width, 0, -_height); //左下
        vertices[1] = new Vector3(_width, 0, -_height); //右下
        vertices[2] = new Vector3(_width, 0, _height); //右上
        vertices[3] = new Vector3(-_width, 0, _height); //左上

        triangles[0] = 1;
        triangles[1] = triangles[3] = 0;
        triangles[2] = triangles[5] = 2;
        triangles[4] = 3;

        uvs[0] = new Vector2(0, 1);
        uvs[1] = new Vector2(0, 0);
        uvs[2] = new Vector2(1, 0);
        uvs[3] = new Vector2(1, 1);

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        meshFilter.sharedMesh = mesh;
        meshRenderer.material = mat;
        mesh.RecalculateNormals();

    }
}
