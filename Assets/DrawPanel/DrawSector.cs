using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSector : RangeShower
{
    #region Public Attr
    /// <summary>
    /// startAngle:开始角度,sectorAngle:扇形多少角度
    /// </summary>
    public float startAngle = 45, sectorAngle = 90;

    /// <summary>
    /// insideRadius:内环半径,outsideRadius:外环半径
    /// </summary>
    public float insideRadius = 3, outsideRadius = 6;

    /// <summary>
    /// 多少角度生成一个顶点
    /// </summary>
    public float sliceAngle = 1;
    #endregion

    public override void UpdateMesh()
    {
        base.UpdateMesh();

        int verticesCount = Mathf.CeilToInt(sectorAngle / sliceAngle);
        float stepUV = 1f / sectorAngle * sliceAngle;
        float tempUVX = -stepUV;

        int tempVC = verticesCount * 2;
        Vector3[] vertices = new Vector3[tempVC+2];
        Vector2[] uvs = new Vector2[tempVC+2];
        int[] triangles = new int[verticesCount * 6];

        for (int i = 0; i <= verticesCount; i++)
        {
            float angle = Mathf.Deg2Rad;

            if (i != verticesCount)
            {
                angle *= startAngle + i * sliceAngle;
                tempUVX += stepUV;
            }
            else
            {
                angle *= startAngle + sectorAngle;
                tempUVX = 1;
            }

            float sinR = Mathf.Sin(angle), cosR = Mathf.Cos(angle);

            Vector3 insidePoint = new Vector3(sinR * insideRadius, 0, cosR * insideRadius)
                , outsidePoint = new Vector3(sinR * outsideRadius, 0, cosR * outsideRadius);

            int tempI = i << 1;
            vertices[tempI] = insidePoint;
            vertices[tempI + 1] = outsidePoint;
            uvs[tempI] = new Vector2(tempUVX, 0);
            uvs[tempI + 1] = new Vector2(tempUVX, 1);
            if(i>0)
            {
                int tempJ = (i - 1) * 6;
                triangles[tempJ] = triangles[tempJ + 3] = tempI - 1;
                triangles[tempJ + 1] = triangles[tempJ + 5] =  tempI;
                triangles[tempJ + 2] = tempI - 2;
                triangles[tempJ + 4] = tempI + 1;
                
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        meshFilter.sharedMesh = mesh;
        meshRenderer.material = mat;
        mesh.RecalculateNormals();
    }
}
