using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class follow : MonoBehaviour
{

    Transform goal;
    float speed = 5f;
    float accuracy = 10f;
    float rotspeed = 1f;

    public GameObject wpmanager;
    GameObject[] wps;
    GameObject currentnode;
    int currentwp = 0;
    Graph g;
    
    void Start()
    {
        wps = wpmanager.GetComponent<wpmanager>().waypoints;
        g = wpmanager.GetComponent<wpmanager>().graph;
        currentnode = wps[0];

        Invoke("GotoHeli", 3);

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
    void LateUpdate()
    {
        if(g.pathlist.Count == 0 || currentwp == g.pathlist.Count)
        return;

        if(Vector3.Distance(g.pathlist[currentwp].getId().transform.position, this.transform.position)< accuracy)
        {
            currentnode = g.pathlist[currentwp].getId();
            currentwp++;

        }

        if(currentwp < g.pathlist.Count)
        {
            goal = g.pathlist[currentwp].getId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,this.transform.position.y,this.transform.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime * rotspeed);
            this.transform.Translate(0,0,speed * Time.deltaTime);
        }
    }

}
