using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawQuad : RangeShower
{

    public override void UpdateMesh(ShapeType shape, float _degree, float _radius, float _innerOff)
    {
        if(shape== ShapeType.obb)
        {
            if(mesh)
            {
                mesh = new Mesh();
            }
            else
            {
                mesh.Clear();
            }

            Vector2 uvCenter = new Vector2(0.5f, 0.5f);
            vertices = new Vector3[4];
            triangles = new int[6];
            uvs = new Vector2[4];
 
        }
    }
}
