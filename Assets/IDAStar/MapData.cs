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

    public SearchNode(int x, int y) : this(new Vector2(x, y))
    {

    }

    public SearchNode(Vector2 pos)
    {
        this.pos = pos;
        parent = null;
    }

    public bool IsEqual(SearchNode node2)
    {
        return NodeMethod.IsEqual(this, node2);
    }

    public List<SearchNode> GetAdjacent()
    {
        return NodeMethod.GetAdjacent(this);
    }

    public bool IsValidPos()
    {
        return NodeMethod.IsValidPos(pos);
    }

    public override string ToString()
    {
        return string.Format(" [{0},{1}] ", (int)pos.x, (int)pos.y);
    }
}

public static class NodeMethod
{
    public static SearchNode GetMinFNode(List<SearchNode> openset)
    {
        int index = 0;
        float min = MapData.width + MapData.height;

        for (int i = 0; i < openset.Count; i++)
        {
            min = openset[i].f;
            index = i;
        }
        return openset[index];
    }

    public static SearchNode GetNode(List<SearchNode> set, SearchNode node)
    {
        for (int i = 0; i < set.Count; i++)
        {
            if (IsEqual(node, set[i]))
            {
                return set[i];
            }
        }
        return null;
    }

    public static bool ContainNode(List<SearchNode> set, SearchNode node)
    {
        for (int i = 0; i < set.Count; i++)
        {
            if (set[i].IsEqual(node))
            {
                return true;
            }
        }
        return false;
    }

    public static void RemoveNode(List<SearchNode> set, SearchNode node)
    {
        for (int i = 0; i < set.Count; i++)
        {
            if (set[i].IsEqual(node))
            {
                set.RemoveAt(i);
                return;
            }
        }
    }

    public static bool IsEqual(SearchNode node1, SearchNode node2)
    {
        return node1.pos.x == node2.pos.x && node1.pos.y == node2.pos.y;
    }

    public static List<SearchNode> GetAdjacent(SearchNode node)
    {
        var pos = node.pos;
        Vector2 up, down, left, right;
        up = new Vector2(pos.x, pos.y - 1);
        down = new Vector2(pos.x, pos.y + 1);
        left = new Vector2(pos.x - 1, pos.y);
        right = new Vector2(pos.x + 1, pos.y);

        List<SearchNode> nodeList = new List<SearchNode>()
        {
            Capacity = 4
        };
        if (IsValidPos(up))
        {
            nodeList.Add(new SearchNode(up));
        }
        if (IsValidPos(down))
        {
            nodeList.Add(new SearchNode(down));
        }
        if (IsValidPos(left))
        {
            nodeList.Add(new SearchNode(left));
        }
        if (IsValidPos(right))
        {
            nodeList.Add(new SearchNode(right));
        }

        return nodeList;
    }

    public static bool IsValidPos(Vector2 pos)
    {
        if (pos.x < 0 || pos.x > MapData.width - 1
            || pos.y < 0 || pos.y > MapData.height - 1)
        {
            return false;
        }
        return MapData.pathMap[(int)pos.y, (int)pos.x] == 0 ? true : false;
    }
}
