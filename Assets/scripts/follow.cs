using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class follow : MonoBehaviour
{

    Transform goal;
    float speed = 5f;
    float accuracy = 1f;
    float rotspeed = 1f;

    public GameObject wpmanager;
    GameObject[] wps;
    GameObject currentnode;
    int currentwp = 0;
    Graph g;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wps = wpmanager.GetComponent<wpmanager>().waypoints;
        g = wpmanager.GetComponent<wpmanager>().graph;
        currentnode = wps[0];
    }




    public void GotoHeli()
    {
        g.AStar(currentnode,wps[0]);
        currentwp=0;
    }

    public void GotoVillage()
    {
        g.AStar(currentnode,wps[0]);
        currentwp=0;
    }

    public void GotoFactory()
    {
        g.AStar(currentnode,wps[0]);
        currentwp=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
