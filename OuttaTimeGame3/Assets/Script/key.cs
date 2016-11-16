using UnityEngine;
using System.Collections;


public class key : MonoBehaviour {

    public GameObject thisGO;
    GameObject player;
    GameObject keyGO;
    GameObject questionMark;
    GameObject doorLeft;
    GameObject doorRight;

	// Use this for initialization
	void Start () {
        if (thisGO.name == "Chest")
        {
            player = GameObject.Find("FPSController");
            keyGO = GameObject.Find("keyImg");
            questionMark = GameObject.Find("questionMark");
            keyGO.SetActive(false);
        }
        doorLeft = GameObject.Find("doorLeft");
        doorRight = GameObject.Find("doorRight");


    }

    // Update is called once per frame
    void Update () {

        if (thisGO.name == "Chest")
        {
            float chestDistance = Vector3.Distance(player.transform.position, thisGO.transform.position);

            if (chestDistance < 7)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    DestroyObject(thisGO);
                    keyGO.SetActive(true);
                    questionMark.SetActive(false);
                    GameObject.Find("doorRight").GetComponent<doorOpen>().withKey = true;
                    GameObject.Find("doorLeft").GetComponent<doorOpen>().withKey = true;

                }
            }

        }

    }
}
