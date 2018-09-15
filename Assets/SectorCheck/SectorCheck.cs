using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SectorCheck : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform targetTS;
    public float radius = 5;
    public float angle = 60;

    private List<Transform> cubeList;
    private float sqrRadius;
    private float cosAngle;

    private void Awake()
    {
        cubeList = new List<Transform>();
        sqrRadius = radius * radius;
        cosAngle = Mathf.Cos(Mathf.Deg2Rad * angle * 0.5f);
        SpawnCubes();
    }

    private void Update()
    {
        CheckInArea();

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

    private void CheckInArea()
    {
        Vector3 nowPos = targetTS.position;
        Vector3 offset;
        Transform tempTS;
        Color endColor;
        for (int i = 0; i < cubeList.Count; i++)
        {
            tempTS = cubeList[i];
            offset = tempTS.position - nowPos;
            if (Vector3.SqrMagnitude(offset) <= sqrRadius)
            {
                offset.Normalize();
                float cos = Vector3.Dot(targetTS.forward, offset);
                if (cos - cosAngle >= 0)
                {
                    endColor = Color.yellow;
                }
                else
                {
                    endColor = Color.white;
                }
            }
            else
            {
                endColor = Color.white;
            }
            tempTS.GetComponent<MeshRenderer>().material.SetColor("_Color", endColor);
        }
    }

    [DrawGizmo(GizmoType.Selected|GizmoType.NonSelected)]
    private void OnDrawGizmos()
    {
        if (!targetTS)
            return;
        Handles.color = new Color(1, 1, 1, 0.2f);
        var newStart = Quaternion.Euler(new Vector3(0, -angle/2 , 0)) * targetTS.forward;
        Handles.DrawSolidArc(targetTS.position, targetTS.up, newStart, angle, radius);
    }

}
