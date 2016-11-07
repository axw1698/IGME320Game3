using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUIText : MonoBehaviour {

    public GameObject currentObj;
    //public GameObject refOBj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(currentObj.name =="StaminaText")
        {
            Text staminaText = currentObj.GetComponent<Text>();
            GameObject staminaObj = GameObject.Find("ScriptHolder");
            int currentStamina = staminaObj.GetComponent<StaminaScript>().returnStamina();
            print("CurrentStamina: " + currentStamina);
            staminaText.text = "Stamina: " + currentStamina+ " (Restore 2 pt after 3 sec while not moving)";
        }
	}
}
