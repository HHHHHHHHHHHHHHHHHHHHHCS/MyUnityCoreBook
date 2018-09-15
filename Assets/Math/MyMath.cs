using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMath : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(FanShe(new Vector3(5, -5, 0), new Vector3(1, 0, 0)));
    }


    /// <summary>
    /// 反射向量
    /// </summary>
    /// <param name="input">输入向量</param>
    /// <param name="normal">normal</param>
    /// <returns></returns>
    private Vector3 FanShe(Vector3 input,Vector3 normal)
    {
        Vector3 output = input - (2*normal * Vector3.Dot(input , normal));
        return output;
    }
}
