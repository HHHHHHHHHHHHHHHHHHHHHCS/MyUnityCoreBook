using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTest : MonoBehaviour {
    private void Awake()
    {
        //LogManager.enable = false;
        LogManager.Log("测试{0}的Log", "DDD");
    }

}
