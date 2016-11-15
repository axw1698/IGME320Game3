using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class StaminaScript : MonoBehaviour {

    public double staminaTotal = 20.0;
    
    double currentStamina;
    double restoreStamina;
    bool run;
    FirstPersonController fpc;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    bool moving;
    float runSpeed;

    // time counter
    float t = 0.0f;
    float threshold = 3.0f; // 3 second;
	// Use this for initialization
	void Start () {
        currentStamina = staminaTotal;
        restoreStamina = 2.0;
        run = false;
        moving = false;
        fpc = GameObject.FindObjectOfType<FirstPersonController>();
        runSpeed = fpc.m_RunSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)||
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)
            )
        {
            moving = true;
            // get the run bool from the script
            if (Input.GetKey(KeyCode.LeftShift))
            {
                print("Running now.....................");
                run = true;
                if (currentStamina <= 0)
                {
                    fpc.m_RunSpeed = fpc.m_WalkSpeed;

                }
                else
                {
                    fpc.m_RunSpeed = runSpeed;
                }
                UseStamina(0.1);

                if(currentStamina <= 0)
                {
                    currentStamina = 0;
                }
                
            }
            print("Moving now.....................");

        }
        else
        {
            moving = false;
            print("Stop moving.....................");
           
        }

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    UseStamina(5.0);
        //}


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

    public void UseStamina(double amount)
    {
        currentStamina -= amount;
        print("Used Stamina...Current Stamina: " + currentStamina);
    }

    public int returnStamina()
    {
        return (int)currentStamina;
    }
}
