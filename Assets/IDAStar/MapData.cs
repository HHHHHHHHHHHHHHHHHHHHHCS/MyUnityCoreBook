using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    public const int width = 6;
    public const int height = 6;
    public static readonly int[,] pathMap = new int[,]{
        {0,0,0,0,-1,0 },
        {0,0,0,0,-1,0 },
        {0,0,0,0,-1,0 },
        {0,-1,-1,-1,-1,0 },
        {0,0,0,-1,0,0 },
        {0,-1,0,0,0,0 }};
}

public class SearchNode
{
    public Vector2 pos;
    public float f;
    public float g;
    public float h;
    public SearchNode parent;

    public SearchNode(Vector2 pos)
    {
        this.pos = pos;
        parent = null;
    }
}
