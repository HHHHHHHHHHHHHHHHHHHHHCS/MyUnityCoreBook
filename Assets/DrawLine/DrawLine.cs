using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawLine : MonoBehaviour
{
    [Serializable]
    public struct LineParam
    {
        public float StartX;
        public float TotalLength;
        public Color LineColor;

        public LineParam(bool isDefault)
        {
            StartX = 0;
            TotalLength = 8;
            LineColor = Color.green;
        }

        public LineParam(float startX, float totalLength, Color lineColor)
        {
            StartX = startX;
            TotalLength = totalLength;
            LineColor = lineColor;
        }
    }


    #region public Attributes
    public Transform target;

    public LineParam lineParam1;
    public LineParam lineParam2;


    [Range(0.1f, 1)]
    public float delat = 0.1f;

    private float maxX = float.MinValue, minX = float.MaxValue;
    private float maxY = float.MinValue, minY = float.MaxValue;
    #endregion

    #region Unity Message 
    private void Update()
    {
        MakeLine(target, lineParam1, (x) =>
        {
            float h = Mathf.Sin(1 * x + 45) * 2;
            return h;
        });

        MakeLine(target, lineParam2, (x) =>
        {
            float h = Mathf.Cos(2 * x + 90) * 1;
            return h;
        });

        DrawDefaultLine();
    }

    #endregion

    #region public Methods


    public void MakeLine(Transform tarTrans, LineParam lineParam, Func<float, float> calcPos)
    {
        if (!tarTrans)
        {
            return;
        }

        float x = tarTrans.position.x + lineParam.StartX;
        if (x < minX)
        {
            minX = x;
        }
        x += lineParam.TotalLength;
        if (x > maxX)
        {
            maxX = x;
        }

        Vector3 PerPos = tarTrans.position;
        for (float i = lineParam.StartX; i < lineParam.TotalLength; i = i + delat)
        {
            float h = calcPos(i);
            Vector3 localPos = new Vector3(i, h, 0);
            Vector3 worldPos = tarTrans.TransformPoint(localPos);
            h = worldPos.y;
            if (h > maxY)
            {
                maxY = h;
            }
            else if (h < minY)
            {
                minY = h;
            }
            if (i != lineParam.StartX)
            {
                Debug.DrawLine(PerPos, worldPos, lineParam.LineColor);
                print(PerPos + "////" + worldPos);
            }
     
            PerPos = worldPos;

        }
    }


    public void DrawDefaultLine()
    {
        Debug.DrawLine(new Vector3(0, minY, 0), new Vector3(0, maxY, 0));
        Debug.DrawLine(new Vector3(minX, 0, 0), new Vector3(maxX, 0, 0));
    }

    #endregion

}
