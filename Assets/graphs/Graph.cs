using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Graph
{
   List<Edge> edges = new List<Edge>();
   List<Node> nodes = new List<Node>();
   public List<Node> pathlist = new List<Node>();

   public Graph(){}

   public void AddNode(GameObject id)
   {
    Node node = new Node(id);
    nodes.Add(node);
   }

   public void AddEdge(GameObject fromnode, GameObject tonode)
   {
    Node from = FindNode(fromnode);
    Node to = FindNode(tonode);

    if(from != null && to != null)
    {
        Edge e = new Edge(from, to);
        edges.Add(e);
        from.edgelist.Add(e);
    }
   }

   Node FindNode(GameObject id)
   {
    foreach (Node n in nodes)
    {
        if(n.getId()==id)
        return n;
    }
    return null;
   }


   public bool AStar(GameObject startId, GameObject endId)
   {

    if(startId == endId)
    {
        pathlist.Clear();
        return false;
    }
    
    Node start = FindNode(startId);
    Node end = FindNode(endId);

    if(start==null || end ==null)
    return false;

    List<Node> open = new List<Node>();
    List<Node> closed = new List<Node>();
    float tentativegscore = 0;
    bool tentativeisbetter;

    start.g=0;
    start.h=distance(start,end);
    start.f = start.h;

    open.Add(start);

    while(open.Count >0)
    {
        int i = lowestF(open);
        Node thisNode = open[i];
        if(thisNode.getId()==endId)
        {
            ReconstructPath(start,end);
            return true;
        }

        open.RemoveAt(i);
        closed.Add(thisNode);
        Node neighbour;
        foreach(Edge e in thisNode.edgelist)
        {
            neighbour = e.endnode;
            if(closed.IndexOf(neighbour)>-1)
            continue;

            tentativegscore = thisNode.g + distance(thisNode,neighbour);
            if(open.IndexOf(neighbour)== -1)
            {
                open.Add(neighbour);
                tentativeisbetter=true;
            }
            else if(tentativegscore < neighbour.g)
            {
                tentativeisbetter = true;
            }
            else 
            tentativeisbetter=false;

            if(tentativeisbetter)
            {
                neighbour.cameFrom=thisNode;
                neighbour.g =tentativegscore;
                neighbour.h = distance(thisNode,end);
                neighbour.f= neighbour.g + neighbour.h;
            }
        }
    }
    return false;
   }

   public void ReconstructPath(Node startId,Node endId)
   {
    pathlist.Clear();
    pathlist.Add(endId);

    var p = endId.cameFrom;
    while(p != startId && p != null)
    {
        pathlist.Insert(0,p);
        p = p.cameFrom;
    }
    pathlist.Insert(0,startId);
   }

   float distance(Node a, Node b)
   {
    return (Vector3.SqrMagnitude(a.getId().transform.position - b.getId().transform.position));
   }

   int lowestF(List<Node> l)
   {
    float lowestF = 0;
    int count = 0;
    int iteratorCount = 0;

    lowestF = l[0].f;

    for(int i =1; i<l.Count;i++)
    {
        if(l[i].f<lowestF)
        {
            lowestF = l[i].f;
            iteratorCount = count;
        }
        count++;
    }
    return iteratorCount;
   }

}
