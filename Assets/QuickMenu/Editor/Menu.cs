using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Menu
{
    /// <summary>
    /// 顶部菜单随便写
    /// </summary>
    [MenuItem("MyMenu/Do Something")]
    private static void DoSomething()
    {
        Debug.Log("Click MyMenu/Do Something");
    }

    /// <summary>
    /// Hierearchy 加菜单 要加GameObject/开头
    /// 第二个参数 第二个参数，默认为false，设为ture则击菜单前就会调用 
    ///     如：检测按钮是否要显示(要谢两个方法，一个参数true控制按钮显示，一个参数false控制点击要做的事) 
    /// 第三个是 位置
    /// </summary>
    /// 
    [MenuItem("GameObject/HierarchyMenu", false)]
    private static void HierarchyMenuFalse()
    {
        Debug.Log("Click HierarchyMenu1");
    }

    [MenuItem("GameObject/HierarchyMenu", true)]
    private static bool HierarchyMenuTrue()
    {
        return Selection.objects.Length > 0;
    }





    /// <summary>
    /// 在Project 界面右键   必须要加Project/开头
    /// 第二个参数 是菜单是否被隐藏了   true为隐藏
    /// 第三个是 位置
    /// </summary>
    [MenuItem("Assets/ProjectMenuItem1")]
    private static void ProjectMenu1()
    {
        Debug.Log("Project ProjectMenu1 ");
    }


    [MenuItem("Assets/ProjectMenuItem2", true)]
    private static void ProjectMenu2()
    {
        Debug.Log("Project ProjectMenu2");
    }

    /// <summary>
    /// 注意和Unity 自带的快捷键冲突
    /// %:ctrl #:shift &:alt
    /// </summary>
    [MenuItem("MyMenu/ShowLog1 %#Z")]
    private static void ShowLogCSZ()
    {
        Debug.Log("Ctrl+Shift+Z is pressed");
    }

    [MenuItem("MyMenu/ShowLog2 %F1")]
    private static void ShowLogCF1()
    {
        Debug.Log("Ctrl+F1 is pressed");
    }
}
