using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Panic : MonoBehaviour {

    public bool caught;  // check if the player is caught by skeleton
    GameObject player;
	GameObject skeleton;
    int panic;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("FPSController");
		skeleton = GameObject.Find ("skeletonController");
        caught = false;
        panic = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
		skeleton = GameObject.Find ("skeletonController");
        // Checks if player is caught
        if (caught)
        {
            print("Let go of me!" + panic);
            GameObject.Find("FPSController").GetComponent<Dragged>().abc = new Vector3(0.5f, 0, 0.5f);

            if (Input.GetKeyDown(KeyCode.X))
            {
                if (panic >= 4)
                {
                    GameObject.Find("FPSController").GetComponent<Dragged>().abc = new Vector3(1, 0, 1);
                    //player.gameObject.SetActive(true);
                    GameObject.Find("ScriptHolder").GetComponent<StaminaScript>().UseStamina(5.0);
                    print("Escaped!");
					skeleton.transform.position = new Vector3(0,0,0);
                    panic = 0;

                }
                else
                {
                    print("Struggling");
                    panic++;
                }
            }

        }

    }
}
