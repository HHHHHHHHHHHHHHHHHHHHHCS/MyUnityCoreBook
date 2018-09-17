using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyTriangle : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform targetTS;
    public Vector3 aPoint = new Vector3(-5, 0, 5)
        , bPoint = new Vector3(3, 0, 3)
        , cPoint = new Vector3(4, 0, -4);

    private List<Transform> cubeList;
    private double len_ab, len_bc, len_ac, s_area;


    private void Awake()
    {
        cubeList = new List<Transform>();
        SpawnCubes();
        if (CheckIsTriangle())
        {
            print(s_area);
        }
    }

    private void Update()
    {
        if (s_area > 0)
        {

            CheckInArea();
        }

    }

    private bool CheckIsTriangle()
    {
        Vector3 vec_ab = aPoint - bPoint,
        vec_ac = aPoint - cPoint,
        vec_bc = bPoint - cPoint;

        var ang1 = Vector3.Dot(vec_ab, vec_ac);

        if (ang1 == 0)
        {
            return false;
        }

        len_ab = vec_ab.magnitude;
        len_bc = vec_bc.magnitude;
        len_ac = vec_ac.magnitude;
        s_area = CalArea(len_ab, len_bc, len_ac)+1e-5;//误差计算
        return true;
    }

    private void SpawnCubes()
    {
        Transform parent = new GameObject("Cubes").transform;
        Transform tempTS;
        for (int y = -5; y <= 5; y++)
        {
            for (int x = -5; x <= 5; x++)
            {
                tempTS = Instantiate(cubePrefab, new Vector3(x, 0, y), Quaternion.identity, parent).transform;
                cubeList.Add(tempTS);
            }
        }
    }

    private double CalArea(double a, double b, double c)
    {
        if (a >= b + c || b > a + c || c > a + b)
        {
            return 0;
        }
        double s = (a + b + c) / 2;
        double area;
        area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        return area;
    }

    private void CheckInArea()
    {
        Vector3 p;
        double s, l_ap, l_bp, l_cp;
        Transform tempTS;
        Color endColor;
        for (int i = 0; i < cubeList.Count; i++)
        {
            tempTS = cubeList[i];

            p = tempTS.position;
            l_ap = (p - aPoint).magnitude;
            l_bp = (p - bPoint).magnitude;
            l_cp = (p - cPoint).magnitude;
            s = CalArea(len_ab, l_ap, l_bp) + CalArea(len_bc, l_cp, l_bp)
                + CalArea(len_ac, l_ap, l_cp);
 
            if (s <= s_area)
            {

                endColor = Color.yellow;
            }
            else
            {
                endColor = Color.white;
            }

            tempTS.GetComponent<MeshRenderer>().material.SetColor("_Color", endColor);
        }
    }

    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    private void OnDrawGizmos()
    {
        if (!targetTS)
            return;
        Gizmos.DrawLine(aPoint, bPoint);
        Gizmos.DrawLine(aPoint, cPoint);
        Gizmos.DrawLine(cPoint, bPoint);
    }

}
