using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class follow : MonoBehaviour
{

    Transform goal;
    float speed = 5f;
    float accuracy = 5f;
    float rotspeed = 10f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentnode;
    int currentwp = 0;
    Graph g;
    
    void Start()
    {
        wps = wpManager.GetComponent<WPmanager>().waypoints;
        g = wpManager.GetComponent<WPmanager>().graph;

        currentnode = wps[0];

       

    }




    public void GotoHeli()
    {
        g.AStar(currentnode,wps[4]);
        currentwp=0;
        Debug.Log("ahhh");
    }

    public void GotoVillage()
    {
        g.AStar(currentnode,wps[3]);
        currentwp=0;
        Debug.Log(g.pathlist.Count);

    }

    public void GotoFactory()
    {
        g.AStar(currentnode,wps[6]);
        currentwp=0;
    }

    public void GotoOil()
    {
        g.AStar(currentnode,wps[0]);
        currentwp=0;
        Debug.Log("ahhh");
    }

    // Update is called once per frame
    void Update()
    {
        if(g.pathlist.Count == 0 || currentwp == g.pathlist.Count)
            return;
    

        if(Vector3.Distance(g.pathlist[currentwp].getId().transform.position, this.transform.position) < accuracy)
        {
            currentnode = g.pathlist[currentwp].getId();
            currentwp++;
            

        }

        if(currentwp < g.pathlist.Count)
        {
            goal = g.pathlist[currentwp].getId().transform;

            Vector3 lookAtGoal = new Vector3(goal.position.x,this.transform.position.y,goal.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime * rotspeed);

            this.transform.Translate(0f,0f, speed * Time.deltaTime);

            
        }
    }

}
