using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTest : MonoBehaviour {
    private void Awake()
    {
        //LogManagerTest();
        MaskLogManagerTest();
    }

    public void LogManagerTest()
    {
        //LogManager.EnableLog = false;
        LogManager.Log("测试{0}的Log", "DDD");
    }

    public void MaskLogManagerTest()
    {
        //MaskLogManager.EnableLog = false;
        MaskLogManager.SysLog("{0}.{1}", 11, 22);
        MaskLogManager.NowLog("{0}", 2333);
        MaskLogManager.EnableTag(MaskDef.Now);
        MaskLogManager.NowLog("NowNow" );
        MaskLogManager.DisableTag( MaskDef.Sys);
        MaskLogManager.SysLog("233333");
        MaskLogManager.EnableTag(MaskDef.Err);
        MaskLogManager.ErrLog("err");
    }
}
