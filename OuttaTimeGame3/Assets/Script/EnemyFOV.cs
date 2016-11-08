﻿using UnityEngine;
using System.Collections;

public class EnemyFOV : MonoBehaviour
{

    RaycastHit target;
    float fov = 120;
    int angleDiv = 24;
    float angleInc;
    float angleStart;
    float dist = 6.0f;
    Vector3 direction;
    Quaternion rotation;
    Quaternion rotStart;
    public GameObject thisGO;
    Seeker seekerScript; // from this GameObject

    // Use this for initialization
    void Start()
    {
        angleInc = fov / angleDiv;
        angleStart = fov / -2;
        rotation = Quaternion.AngleAxis(angleInc, Vector3.up);
        rotStart = Quaternion.AngleAxis(angleStart, Vector3.up);
        thisGO = this.gameObject;
        seekerScript = thisGO.GetComponent<Seeker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Seek())
        {
            //write seeking player code here
            Debug.Log("AHHHH, I'm hit!");
            seekerScript.followPath = false;
        }

        else
        {
            //write idle code here
            seekerScript.followPath = true;
        }
    }

    bool Seek()
    {
        bool hitPlayer = false;

        direction = rotStart * transform.forward;
        Debug.DrawLine(transform.forward, transform.forward * dist);
        for (int i = 0; i < angleDiv; i++)
        {
            Debug.DrawLine(transform.position, direction * dist, Color.green);
            if (Physics.Raycast(transform.position, direction, out target, dist))
            {
                if (target.collider.gameObject.tag == "Player")
                {
                    hitPlayer = true;
                }
            }
            direction = rotation * direction;
        }

        return hitPlayer;
    }
}