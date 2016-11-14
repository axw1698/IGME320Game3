﻿using UnityEngine;
using System.Collections;

public class ActivateTorch : MonoBehaviour {

    GameObject torch;
    GameObject torchSource;
    GameObject fireSource;
    GameObject torchFire;
    GameObject torchLight;
    // Use this for initialization
    void Start () {
        torch = GameObject.Find("Torch");
        torchSource = GameObject.Find("TorchSource");
        fireSource = GameObject.Find("fireSource");
        torchFire = GameObject.Find("flame");
        torchLight = GameObject.Find("torch light");
        torch.SetActive(false);
        torchFire.SetActive(false);
        torchLight.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        float getTorchDistance = Vector3.Distance(transform.position, torchSource.transform.position);
        if(getTorchDistance < 7)
        {
            if (Input.GetKey(KeyCode.E))
            {
                torch.SetActive(true);
            }
        }

     
        float getFireDistance = Vector3.Distance(transform.position, fireSource.transform.position);
        if (torch.activeSelf && getFireDistance < 7 )

        {
            if(Input.GetKey(KeyCode.E))
            {
                torchFire.SetActive(true);
                torchLight.SetActive(true);

            }
        }

        Debug.Log(torchFire.activeSelf);
    }
}
