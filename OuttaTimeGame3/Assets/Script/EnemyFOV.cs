using UnityEngine;
using System.Collections;

public class EnemyFOV : MonoBehaviour {

    RaycastHit target;
    float fov = 120;
    int angleDiv = 12;
    float angleInc;
    float angleStart;
    float dist = 10.0f;
    Vector3 direction;
    Quaternion rotation;
    Quaternion rotStart;
	// Use this for initialization
	void Start () {
        angleInc = fov / angleDiv;
        angleStart = fov / -2;
        rotation = Quaternion.AngleAxis(angleInc, Vector3.up);
        rotStart = Quaternion.AngleAxis(angleStart, Vector3.up);
    }
	
	// Update is called once per frame
	void Update () {
        if(Seek())
        {
            //write seeking player code here
            Debug.Log("AHHHH, I'm hit!");
        }

        else
        {
            //write idle code here
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
