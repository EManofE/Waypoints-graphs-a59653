using UnityEngine;

public class followwp : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentwp = 0;

    public float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentwp].transform.position)<3)
        currentwp ++;

        if(currentwp>=waypoints.Length)
        currentwp =0;

        this.transform.LookAt(waypoints[currentwp].transform);
        this.transform.Translate(0,0,speed * Time.deltaTime);
    }
}
