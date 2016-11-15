using UnityEngine;
using System.Collections;

public class Dragged : MonoBehaviour {

    GameObject Cam;
    GameObject FPC;
    GameObject skeleton;
	// Use this for initialization
	void Start () {
        Cam = GameObject.Find("DraggedCam");
        FPC = GameObject.Find("FPSController");
        skeleton = GameObject.Find("skeletonController");
        Cam.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
  
        Vector3 camPos = new Vector3(skeleton.transform.position.x - 2, skeleton.transform.position.y, skeleton.transform.position.z);
        float lookDown = Input.GetAxis("Vertical") * 30.0f;
        float dragZ = skeleton.transform.rotation.z;
        Quaternion target = Quaternion.Euler(lookDown, 0, dragZ);

        Cam.transform.position = camPos;
        Cam.transform.rotation = target;

        float dragDistance = Vector3.Distance(transform.position, skeleton.transform.position);
        if(dragDistance <= 1.5f)
        {
            FPC.gameObject.SetActive(false);
            Cam.gameObject.SetActive(true);
        }
        else
        {
            FPC.gameObject.SetActive(true);
            Cam.gameObject.SetActive(false);
        }
    }
}
