using UnityEngine;
using UnityEditor;


public static class SHGameObject
{

    public const string showHidekey = "MyTool/ShowHideGo %h";
    public const string showKey = "MyTool/ShowGo %#h";
    public const string hidekey = "MyTool/HideGo %&h";

    //根据当前有没有选中物体来判断可否用快捷键
    [MenuItem(showHidekey, true),MenuItem(showKey, true),MenuItem(hidekey, true)]
    private static bool ValidateSelectEnableDisable()
    {
        GameObject[] go = GetSelectedGameObjects() as GameObject[];

        if (go == null || go.Length == 0)
            return false;
        return true;
    }

    [MenuItem(showHidekey)]
    static void SelectShoHide()
    {
        bool enable = false;
        GameObject[] gos = GetSelectedGameObjects() as GameObject[];

        foreach (GameObject go in gos)
        {
            enable = !go.activeInHierarchy;
            EnableGameObject(go, enable);
        }
    }

    [MenuItem(showKey)]
    static void SelectShow()
    {
        GameObject[] gos = GetSelectedGameObjects() as GameObject[];

        foreach (GameObject go in gos)
        {
            EnableGameObject(go, true);
        }
    }

    [MenuItem(hidekey)]
    static void SelectHide()
    {
        GameObject[] gos = GetSelectedGameObjects() as GameObject[];

        foreach (GameObject go in gos)
        {
            EnableGameObject(go, false);
        }
    }

    //获得选中的物体
    static GameObject[] GetSelectedGameObjects()
    {
        return Selection.gameObjects;
    }

    //激活或关闭当前选中物体
    public static void EnableGameObject(GameObject parent, bool enable)
    {
        parent.gameObject.SetActive(enable);
    }

}