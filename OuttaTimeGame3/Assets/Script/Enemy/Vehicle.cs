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
    public float maxSpeed = 6.0f;
    public float maxForce = 12.0f;
    public float radius = 3.0f;
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


    protected void ApplyForce(Vector3 steeringForce)
    {
        acceleration = steeringForce / mass;

    }


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

    //Not so sure
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
        else {
            //Set the magnitude of the velocity
            desired = Vector3.ClampMagnitude(desired, maxSpeed);
        }

        steeringForce = desired - velocity;

        return steeringForce;
    }




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
}