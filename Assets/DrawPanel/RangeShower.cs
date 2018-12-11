using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class RangeShower : MonoBehaviour
{
    public enum ShapeType
    {
        none,
        sectir,
        obb,
        ring,

    }

    #region Public Attr
    public ShapeType shapeType = ShapeType.none;
    public float degree = 120;
    public float intervalDegree = 10;
    public float radius = 5;
    public float innerOff = 2;
    public Material circleIndicator;
    public Material rectIndicator;
    #endregion

    private void LateUpdate()
    {
        enabled = false;
        UpdateMesh(shapeType, degree, radius, innerOff);
    }

    public virtual void UpdateMesh(ShapeType shape,float _degree,float _radius,float _innerOff)
    {

    }
}
