using UnityEngine;
using System.Collections;

public class Seeker : Vehicle {

    //Should it move?
    public bool followPath;

    //The movement points
    public Vector3[] movementPoints;


    //Also not sure why I need this
    //Starting from where?
    private Vector3 startingPosition;

    //Not sure why I need this
    //Where I was - list index
    private int prevPoint;

    //Where I'm going - list index
    private int nextPoint = 0;

    public GameObject seekerTarget;

	//WEIGHTING!!!!!!!!!!!!
	public float seekWeight=75.0f;
	public float alignWeight=20.0f;
	public float cohesionWeight=20.0f;
	public float seperationWeight=20.0f;
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
        movementPoints = new Vector3[6];

        ultimateForce = Vector3.zero;

	}

	protected override void CalcSteeringForces()
	{
		//reset the ultimate force
		ultimateForce = Vector3.zero;

        //Am I set to follow a path? Does the paths have points?
        if (followPath)
        {


            //get the next movement point in the list
            Vector3 temp = movementPoints[nextPoint];


            //check distance between me and the movement point
            temp = transform.position - temp;



            //if I'm within units from the point, find the next point
            //if I reach the end of the list, change movement point
            //back to the beginning of the list
            if (temp.magnitude <= 8)
            {
                if (nextPoint == movementPoints.Length - 1)
                {
                    nextPoint = 0;
                }
                else {
                    nextPoint = nextPoint + 1;
                }
            }



            //seek next determined spot
            Vector3 followForce = Seek(movementPoints[nextPoint]);

            //limiting the steering force
            followForce = Vector3.ClampMagnitude(followForce, maxForce);

            //apply steering force to the acceleration (AppplyForce())
            ApplyForce(followForce);


        }
        else
        { 

        //get a seeking force (based on char movement - for now, just sek)
        Vector3 seekForce = Seek (seekerTarget.transform.position)*seekWeight;



		//add that seeking force to alternate steering for
		ultimateForce+=seekForce;



        //limiting the steering force
        ultimateForce =Vector3.ClampMagnitude (ultimateForce,maxForce);

		//apply steering force to the acceleration (AppplyForce())
		ApplyForce (ultimateForce);
        }

	}
}
