using UnityEngine;
using System.Collections;

public class Seeker : Vehicle {

    //Should it move?
    public bool followPath;

    // Waypoints
    public Waypoint[] path;


    //Also not sure why I need this
    //Starting from where?
    private Vector3 startingPosition;

    //Not sure why I need this
    //Where I was - list index
    //private int prevPoint;

    //Where I'm going - list index
    private int currentNode = 0;

    public GameObject seekerTarget;
    public Waypoint waypointTarget;

	//WEIGHTING!!!!!!!!!!!!
	public float seekWeight = 75.0f;
	public float alignWeight = 20.0f;
	public float cohesionWeight = 20.0f;
	public float seperationWeight = 20.0f;
	public float avoidWeight = 120.0f;


	//Ultimate force the will be applyed
	private Vector3 ultimateForce;


	//Safe distance
	public float safeDistance = 10.0f;


	// Call Inherited Start and then do our own
	override public void Start () {
		base.Start();
        //Testing
        maxForce = 14.0f;
        maxSpeed = 10f;

        isCat = false;
        followPath = true;

        startingPosition = gameObject.transform.position;
        
        ultimateForce = Vector3.zero;

        // Create the path
        path = new Waypoint[7];
        path[0] = new Waypoint(GameObject.Find("WP0").transform.position, GameObject.Find("WP1").transform.position);
        path[1] = new Waypoint(GameObject.Find("WP1").transform.position, GameObject.Find("WP2").transform.position);
        path[2] = new Waypoint(GameObject.Find("WP2").transform.position, GameObject.Find("WP3").transform.position);
        path[3] = new Waypoint(GameObject.Find("WP3").transform.position, GameObject.Find("WP4").transform.position);
        path[4] = new Waypoint(GameObject.Find("WP4").transform.position, GameObject.Find("WP5").transform.position);
        path[5] = new Waypoint(GameObject.Find("WP5").transform.position, GameObject.Find("WP6").transform.position);
        path[6] = new Waypoint(GameObject.Find("WP6").transform.position, GameObject.Find("WP0").transform.position);
        
    }

    protected override void CalcSteeringForces()
	{
		//reset the ultimate force
		ultimateForce = Vector3.zero;

        //Am I set to follow a path? Does the paths have points?
        if (followPath)
        {
            // Get the waypoint
            waypointTarget = path[currentNode];

            Vector3 steeringForce = Seek(waypointTarget.GetStart) * seekWeight;

            // Limit the steering force
            steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);

            // Apply it to accerleration
            ApplyForce(steeringForce);

            // Reset
            steeringForce = Vector3.zero;

            // Get next waypoint
            if (Vector3.Distance(transform.position, path[currentNode].GetStart) <= 3.0f)
            {
                if (currentNode == path.Length-1)
                {
                    // Reset
                    currentNode = 0;
                }
                else
                {
                    currentNode++;
                }
            }
            
            
            ////get the next movement point in the list
            //Vector3 point = path[nextPoint].transform.position;

            ////check distance between me and the movement point
            //point = transform.position - point;

            ////if I'm within units from the point, find the next point
            ////if I reach the end of the list, change movement point
            ////back to the beginning of the list
            //if (point.magnitude <= 8)
            //{
            //    if (nextPoint == path.Length - 1)
            //    {
            //        nextPoint = 0;
            //    }
            //    else {
            //        nextPoint = nextPoint + 1;
            //    }
            //}

            ////seek next determined spot
            //Vector3 followForce = Seek(path[nextPoint].transform.position);

            ////limiting the steering force
            //followForce = Vector3.ClampMagnitude(followForce, maxForce);

            ////apply steering force to the acceleration (AppplyForce())
            //ApplyForce(followForce);

        }
        else
        { 

        //get a seeking force (based on char movement - for now, just sek)
        Vector3 seekForce = Seek (seekerTarget.transform.position)*seekWeight;

		//add that seeking force to alternate steering for
		ultimateForce+=seekForce;

        //limiting the steering force
        ultimateForce = Vector3.ClampMagnitude (ultimateForce,maxForce);

		//apply steering force to the acceleration (AppplyForce())
		ApplyForce (ultimateForce);
        }

	}
    
}
