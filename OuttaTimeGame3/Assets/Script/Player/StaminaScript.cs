using UnityEngine;
using System.Collections;

public class StaminaScript : MonoBehaviour {

    public int staminaTotal = 20;
    int currentStamina;
    int restoreStamina;

    bool moving;

    // time counter
    float t = 0.0f;
    float threshold = 3.0f; // 3 second;
	// Use this for initialization
	void Start () {
        currentStamina = staminaTotal;
        restoreStamina = 2;

        moving = false;
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            moving = true;
            print("Moving now.....................");

        }
        else
        {
            moving = false;
            print("Stop moving.....................");

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UseStamina(5);
        }


        if (moving == false)
        {
            // over time to restore stamina
            if (currentStamina < staminaTotal)
            {
                t += Time.deltaTime;

                if (t >= threshold) // time to increment 
                {
                    currentStamina += restoreStamina;
                    if (currentStamina >= staminaTotal) // if over max, set back to max
                    {
                        currentStamina = staminaTotal;
                    }
                    print("Restore stamina:  time： " + t + "  Current Stamina: " + currentStamina);
                    t = 0;
                }
            }
        }
	}

    void UseStamina(int amount)
    {
        currentStamina -= amount;
        print("Used Stamina...Current Stamina: " + currentStamina);
    }

    public int returnStamina()
    {
        return currentStamina;
    }
}
