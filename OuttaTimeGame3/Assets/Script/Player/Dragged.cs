using UnityEngine;
using System.Collections;

public class Dragged : MonoBehaviour {

    GameObject Cam;
    GameObject FPC;
    GameObject skeleton;
    GameObject LookTarget;
    GameObject ghost;
    GameObject xSprite;

    public Vector3 abc;

    public Seeker mySeek;
	GameObject trigger;
	// Use this for initialization
	void Start () {
        Cam = GameObject.Find("FirstPersonCharacter");
        FPC = GameObject.Find("FPSController");
        skeleton = GameObject.Find("skeletonController");
        LookTarget = GameObject.Find("feet");
        ghost = GameObject.Find("Ghost");
        xSprite = GameObject.Find("X");
        //Cam.gameObject.SetActive(false);

        abc = new Vector3(2.0f, 0, 2.0f);

        mySeek = skeleton.GetComponent<Seeker>();

		trigger = GameObject.Find ("something");
		skeleton = GameObject.Find ("skeletonController");
		skeleton.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
			float getTriggerDistance = Vector3.Distance (trigger.transform.position, this.transform.position);
			if (getTriggerDistance < 2) 
			{
				skeleton.SetActive(true);
			}


			if (skeleton.activeSelf) {
			skeleton = GameObject.Find ("skeletonController");
			Vector3 camPos = new Vector3 (skeleton.transform.position.x, skeleton.transform.position.y, skeleton.transform.position.z - 2.0f);
			//float lookDown = Input.GetAxis("Vertical") * 30.0f;
			//float dragZ = skeleton.transform.rotation.z;
			//Quaternion target = Quaternion.Euler(lookDown, 0, dragZ);

			//Cam.transform.position = camPos;
			//Cam.transform.rotation = target;
        
			float dragDistance = Vector3.Distance (transform.position, skeleton.transform.position);
			if (dragDistance <= 3.5f) {
				//FPC.gameObject.SetActive(false);
				//Cam.gameObject.SetActive(true);

				mySeek.followPath = false;
				mySeek.seekerTarget = ghost;

				FPC.GetComponent<Panic> ().caught = true;
				Cam.transform.LookAt (LookTarget.transform);
				//xSprite.SetActive(true);

				print ("Ah!");

               

                //Cam.transform.position = skeleton.transform.position;
                transform.position = skeleton.transform.position - abc;
			} 
			else {
				//FPC.gameObject.SetActive(true);
				//Cam.gameObject.SetActive(false);

				//transform.position = skeleton.transform.position - abc;

				mySeek.followPath = true;
				mySeek.seekerTarget = FPC;
				FPC.GetComponent<Panic> ().caught = false;
				//xSprite.SetActive(false);

			}
		}
	}
}
