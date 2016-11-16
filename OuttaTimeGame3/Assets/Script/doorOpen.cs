using UnityEngine;
using System.Collections;

public class doorOpen : MonoBehaviour {

    public GameObject thisGO;
    bool openDoor = false;
    public bool withKey = false;
    float yRotationRight = 2.0f;
    float yRotationLeft = 180.0f;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        print("FPSController");
        if (this.thisGO.name == "doorRight")
        {
            float doorRightDis = Vector3.Distance(transform.position, thisGO.transform.position);
            if (doorRightDis < 5)
            {
                print("In distance");
                if (withKey == true)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        openDoor = true;
                    }
                }
            }
        }
        if (this.thisGO.name == "doorLeft")
        {
            float doorLeftDis = Vector3.Distance(transform.position, thisGO.transform.position);
            if (doorLeftDis < 5)
            {
                print("In distance");
                if (withKey == true)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        openDoor = true;
                    }
                }
            }
        }
        if (openDoor == true)
        {

            if (thisGO.name == "doorRight")
            {
                if (thisGO.transform.eulerAngles.y <= 90.0f)
                {
                    //print("Open door" + thisGO.transform.eulerAngles.y);

                    //print("Open door" + thisGO.transform.rotation.y);
                    yRotationRight += 2;
                    //thisGO.transform.Rotate(0, 2, 0);
                    transform.eulerAngles = new Vector3(0, yRotationRight, 0);
                }
            }
            if (thisGO.name == "doorLeft")
            {
                if (thisGO.transform.eulerAngles.y >= 90.0f)
                {
                    //print("Open door" + thisGO.transform.eulerAngles.y);
                    yRotationLeft -= 2;
                    //thisGO.transform.Rotate(0, 2, 0);
                    transform.eulerAngles = new Vector3(0, yRotationLeft, 0);
                }
            }
            //else if(thisGO.transform.rotation.y >= 90)
            //{
            //    print("Stop open door");
            //    openDoor = false;
            //    return;
            //    //thisGO.transform.Rotate(0, 0, 0);

            //}

        }
    }
}
