﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Panic : MonoBehaviour {

    public bool caught;  // check if the player is caught by skeleton
    GameObject player;
    int panic;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("FPSController");
        caught = false;
        panic = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Checks if player is caught
        if (caught)
        {
            print("Let go of me!" + panic);
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (panic >= 4)
                {
                    player.gameObject.SetActive(true);
                    GameObject.Find("ScriptHolder").GetComponent<StaminaScript>().UseStamina(5.0);
                    print("Escaped!");
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