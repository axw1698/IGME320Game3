using UnityEngine;
using System.Collections;

//use the Generic system here to make use of a Flocker list later on
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]

abstract public class Vehicle : MonoBehaviour
{

    //no position - transform.position will be used instead
    protected Vector3 acceleration;
    protected Vector3 velocity;
    protected Vector3 desired;
    protected bool isCat = true;


    public Vector3 Velocity
    {
        get { return velocity; }
    }

    //Fields
    public float maxSpeed = 12.0f;
    public float maxForce = 15.0f;
    public float radius = 1.0f;
    public float mass = 1.0f;


    //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    //Distance to slow down
    public float slowDist = 30.0f;

    //Character Controll
    CharacterController charControl;


    virtual public void Start()
    {
        acceleration = Vector3.zero;
        velocity = Vector3.zero;
        desired = Vector3.zero;

        //store access to character controller component
        charControl = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    protected void Update()
    {
        //Calculate all necessary steering forces
        CalcSteeringForces();

        //add accel to vel
        velocity += acceleration * Time.deltaTime;

        //limit vel to max speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.forward = velocity.normalized;

        //change position
        charControl.Move(velocity * Time.deltaTime);

        //reset acceleration to 0
        acceleration = Vector3.zero;
    }


    abstract protected void CalcSteeringForces();

    // Apply forces
    protected void ApplyForce(Vector3 steeringForce)
    {
        acceleration = steeringForce / mass;

    }

    // Seek
    protected Vector3 Seek(Vector3 targetPosition)
    {
        //Zero out the steering force
        Vector3 steeringForce = Vector3.zero;

        desired = targetPosition - transform.position;

        //Set the y component to zero
        desired.y = 0;

        //Set the magnitude of the velocity
        desired = Vector3.ClampMagnitude(desired, maxSpeed);

        steeringForce = desired - velocity;

        return steeringForce;
    }

    // Arrive
    protected Vector3 Arrival(Vector3 arrivalPosition)
    {
        //Zero out the steering force
        Vector3 steeringForce = Vector3.zero;

        desired = arrivalPosition - transform.position;

        //Set the y component to zero
        desired.y = 0;

        //Find the distance
        float distance = desired.magnitude;

        if (distance <= slowDist)
        {

            float m = distance / slowDist * maxSpeed;
            desired.Normalize();
            desired = desired * m;
        }
        else
        {
            //Set the magnitude of the velocity
            desired = Vector3.ClampMagnitude(desired, maxSpeed);
        }

        steeringForce = desired - velocity;

        return steeringForce;
    }

    // Align
    public Vector3 Alignment(Vector3 alignVector)
    {
        Vector3 steeringForce = Vector3.zero;

        //Get the flock direction from game manager object and normalize it
        desired = alignVector.normalized;

        //Multiply desired velocy with max speed
        desired = desired * maxSpeed;

        //Calculate the steering force
        steeringForce = desired - velocity;

        return steeringForce;
    }

    protected Vector3 AvoidObstacle(GameObject obst, float safeDist)
    {
        // Reset
        desired = Vector3.zero;

        // Get the obstacle's radius
        float obRadius = obst.GetComponent<ObstacleScript>().Radius;

        // Calculate the distance from obstacle
        Vector3 vectToCenter = obst.transform.position - transform.position;

        if (safeDist < vectToCenter.magnitude)
        {
            return Vector3.zero;
        }
        if (Vector3.Dot(vectToCenter, transform.forward) < 0)
        {
            return Vector3.zero;
        }

        // Find the distance between the centers of vehicle and obstacle
        float distance = Vector3.Dot(vectToCenter, transform.right);

        if (Mathf.Abs(distance) > (radius + obRadius))
        {
            return Vector3.zero;
        }
        else if (distance > 0)
        {
            // Turn left
            desired = transform.right * -maxSpeed;
            Debug.DrawLine(transform.position, obst.transform.position, Color.green);
        }
        else
        {
            // Turn right
            desired = transform.right * maxSpeed;
            Debug.DrawLine(transform.position, obst.transform.position, Color.red);
        }

        return desired;
    }

}