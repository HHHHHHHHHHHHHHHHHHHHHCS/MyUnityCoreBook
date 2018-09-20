using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPick : MonoBehaviour
{
    public Vector3 normal = Vector3.up;
    public float speed = 1;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                //Debug.Log(hit.collider.gameObject);
                if(Vector3.Dot(ray.direction.normalized,normal)==0)
                {
                    return;
                }
                hit.collider.transform.position =
                    CalPos(Camera.main.transform.position, ray.direction.normalized
                    , normal, speed);
            }
        }
    }

    private Vector3 CalPos(Vector3 p0,Vector3 dir,Vector3 nor,float d)
    {
        float t = (d - Vector3.Dot(p0, nor)) / Vector3.Dot(dir, nor);
        return p0 + t * dir;
    }
}
