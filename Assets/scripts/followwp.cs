using UnityEngine;

public class followwp : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentwp = 0;

    public float speed = 10.0f;
    public float rotspeed;
    public float lookahead = 10f;

    GameObject tracker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }


    void ProgressTracker()
    {

        if(Vector3.Distance(tracker.transform.position, this.transform.position)>lookahead) return;
        
        if(Vector3.Distance(this.transform.position, waypoints[currentwp].transform.position)<10)
        currentwp++;

        if(currentwp>= waypoints.Length)
        currentwp = 0;

        tracker.transform.LookAt(waypoints[currentwp].transform);
        tracker.transform.Translate(0,0,(speed +20)*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();

       // this.transform.LookAt(waypoints[currentwp].transform);


        Quaternion lookatwp= Quaternion.LookRotation(waypoints[currentwp].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,lookatwp, rotspeed * Time.deltaTime);
        this.transform.Translate(0,0,speed * Time.deltaTime);
    }
}
