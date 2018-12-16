using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
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
    public Material mat;
    #endregion

    #region protected Attr
    protected Mesh mesh;
    protected MeshFilter meshFilter;
    protected MeshRenderer meshRenderer;

    protected Vector3[] vertices;
    protected int[] triangles;
    protected Vector2[] uvs;

    protected int lastCount;
    #endregion

    protected void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void LateUpdate()
    {
        enabled = false;
        UpdateMesh();
    }

    public virtual void UpdateMesh()
    {
        if (!mesh)
        {
            mesh = new Mesh();
            mesh.name = "New Mesh";
        }
        else
        {
            mesh.Clear();
        }
    }
}
