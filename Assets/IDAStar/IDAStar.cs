using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDAStar : MonoBehaviour
{
    private void FindWay(SearchNode startNode,SearchNode endNode)
    {
        List<SearchNode> openSet = new List<SearchNode>();
        List<SearchNode> closeSet = new List<SearchNode>();

        SearchNode currentNode = startNode;

        while(currentNode.IsEqual(endNode))
        {
            List<SearchNode> adjacentNode = currentNode.GetAdjacent();
            for(int i=0;i<adjacentNode.Count;i++)
            {

            }

            if(openSet.Count==0)
            {
                break;
            }

            //TODO:
        }
    }
}
