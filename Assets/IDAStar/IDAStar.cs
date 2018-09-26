using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDAStar : MonoBehaviour
{
    private void Awake()
    {
        SearchNode startNode = new SearchNode(3,0);
        SearchNode endNode = new SearchNode(5,0);
        FindWay(startNode, endNode);
    }

    private void FindWay(SearchNode startNode,SearchNode endNode)
    {
        List<SearchNode> openSet = new List<SearchNode>();
        List<SearchNode> closeSet = new List<SearchNode>();

        SearchNode currentNode = startNode;

        //find
        while(!currentNode.IsEqual(endNode))
        {
            List<SearchNode> adjacentNode = currentNode.GetAdjacent();
            for(int i=0;i<adjacentNode.Count;i++)
            {//寻找附近的八个点
                
                var tryNode = adjacentNode[i];
                if (NodeMethod.ContainNode(closeSet,tryNode))
                {//判断这个点是否走过
                    continue;
                }

                if(NodeMethod.ContainNode(openSet,tryNode))
                {//判断这个点是否已经被添加到待走列表
                    //判断G值计算最近的点
                    var cur_g = currentNode.g + 1;

                    if(cur_g<tryNode.g)
                    {
                        tryNode.parent = currentNode;
                        tryNode.g = cur_g;
                        tryNode.f = tryNode.g + tryNode.h;
                    }
                }
                else
                {//如果这个点还没有走过 直接添加
                    tryNode.parent = currentNode;
                    tryNode.h = Mathf.Abs(tryNode.pos.x - endNode.pos.x)
                        + Mathf.Abs(tryNode.pos.y - endNode.pos.y);
                    tryNode.g = currentNode.g + 1;
                    tryNode.f = tryNode.g + tryNode.h;
                    openSet.Add(tryNode);
                }
            }

            if(openSet.Count==0)
            {
                break;
            }

            currentNode = NodeMethod.GetMinFNode(openSet);
            NodeMethod.RemoveNode(openSet, currentNode);
            closeSet.Add(currentNode);
        }

        //out
        if(currentNode.IsEqual(endNode))
        {
            Stack<SearchNode> path = new Stack<SearchNode>();//翻转列表
            SearchNode node = NodeMethod.GetNode(closeSet, endNode);
            while(node!=null)
            {
                path.Push(node);
                node = node.parent;
            }


            string str = "Path is: ";
            node = path.Pop();
            while(path.Count>0)
            {
                str += node;
                node = path.Pop();
            }
            str += endNode;
            Debug.Log(str);
        }
        else
        {
            Debug.Log("Can't find the way!");
        }
    }
}
