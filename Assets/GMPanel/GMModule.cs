using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GMModule 
{
    #region Private Attributes
    private static GMModule _instance;
    public static GMModule Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = new GMModule();
                _instance.Init();
            }
            return _instance;
        }
    }

    private readonly Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();

    #endregion

    #region Public Methods
    public void Init()
    {
        this.methods.Clear();
        Type type = typeof(GMModule);
        var methods = type.GetMethods();
        foreach(var item in methods)
        {
            var attr = item.GetCustomAttributes(typeof(GMCommondAttribute),false);
            if(attr!=null && attr.Length>0)
            {
                GMCommondAttribute gmc = attr[0] as GMCommondAttribute;
                this.methods.Add(gmc.cmd, item);

            }
        }
    }
    #endregion

    public string Call(string input)
    {
        var tmpStr = input.Split(' ');
        if (methods.ContainsKey(tmpStr[0]))
        {
            List<string> param = new List<string>();
            for (int i=1; i<tmpStr.Length;i++)
            {
                param.Add(tmpStr[i]);
            }

            var method = methods[tmpStr[0]];
            var info = method.GetCustomAttributes(typeof(GMCommondAttribute),
                false)[0] as GMCommondAttribute;

            if (param.Count != info.paramNum)
            {
                return "Usage:" + info.usage;
            }
            else
            {
                return methods[tmpStr[0]].Invoke(
                    this, new object[] { param.ToArray() }) as string;
            }
        }
        else
        {
            return "Common Not Fount!";
        }
    }


    [GMCommond("userID",0,"userID | 显示玩家ID")]
    public string ShowID(string[] args)
    {
        int userID = 666;
        return "User id is :" + userID;
    }

    [GMCommond("lvUp", 1, "lvUp 80 | 升级到xx")]
    public string LevelUp(string[] args)
    {
        return "level up to " + args[0];
    }
}
