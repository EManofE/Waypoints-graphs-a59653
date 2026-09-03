using UnityEngine;

public class Edge 
{
  public Node startnode;
  public Node endnode;

  public Edge(Node from, Node to)
  {
    startnode = from;
    endnode = to;
  }
}
