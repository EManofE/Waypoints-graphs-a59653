using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Graph
{
   List<Edge> edges = new List<Edge>();
   List<Node> nodes = new List<Node>();
   List<Node> pathlist = new List<Node>();

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

}
