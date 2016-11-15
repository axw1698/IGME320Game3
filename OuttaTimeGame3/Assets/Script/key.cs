using UnityEngine;
using System.Collections;


public class key : MonoBehaviour {

    public GameObject thisGO;
    GameObject player;
    GameObject keyGO;
    GameObject questionMark;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("FPSController");
        keyGO = GameObject.Find("keyImg");
        questionMark = GameObject.Find("questionMark");
        keyGO.SetActive(false);


    }

    // Update is called once per frame
    void Update () {

        if (thisGO.name == "Chest")
        {
            float getDistance = Vector3.Distance(player.transform.position, thisGO.transform.position);

            if (getDistance < 7)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    DestroyObject(thisGO);
                    keyGO.SetActive(true);
                    questionMark.SetActive(false);
                }
            }
            
        }

    }
}
