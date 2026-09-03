using UnityEngine;

public class followwp : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentwp = 0;

    public float speed = 10.0f;
    public float rotspeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentwp].transform.position)<10)
        currentwp ++;

        if(currentwp>=waypoints.Length)
        currentwp =0;

        //this.transform.LookAt(waypoints[currentwp].transform);


        Quaternion lookatwp= Quaternion.LookRotation(waypoints[currentwp].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,lookatwp, rotspeed * Time.deltaTime);
        this.transform.Translate(0,0,speed * Time.deltaTime);
    }
}
