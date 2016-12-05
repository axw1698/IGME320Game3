using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class HintText : MonoBehaviour {

    public GameObject text;
    int messageState = 0;

    // message bool
    bool message2Appear = false;
    bool message3Appear = false;
    bool message4Appear = false;
    bool message5Appear = false;
    public bool withKey = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Text currectText = text.GetComponent<Text>();
        if (withKey == true)
        {
            messageState = 7;
        }
        switch (messageState)
        {
            case 0:
                currectText.text = "Hmm......how can I get out of this place.....?";
                break;
            case 1:
                currectText.text = "The skeleton looks danger.... I should probably avoid it...";

                break;
            case 2:
                currectText.text = "The demon over there is protecting something. It might be the key to escape!";

                break;
            case 3:
                currectText.text = "I need to find a way to make the demon disappear";

                break;
            case 4:
                currectText.text = "Trees..? Maybe I can find something useful...";
                break;
            case 5:
                currectText.text = "Torch...... I need to find a way to light it up.";
                break;
            case 6:
                currectText.text = "This might work !";

                break;
            case 7:
                currectText.text = "I got the key ！ I can finally leave this place";
                break;
        }

        
	}

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        switch(other.gameObject.name)
        {
            case "stage1":
                messageState = 1;
                break;
            case "stage2":
                if(message2Appear==false)
                {
                    messageState = 2;
                    message2Appear = true;
                }
                break;
            case "stage3":
                if (message3Appear == false)
                {
                    messageState =3;
                    message3Appear = true;
                }
                break;
            case "stage4":
                if (message4Appear == false && message3Appear == true)
                {
                    messageState = 4;
                    message4Appear = true;
                }
                break;
            case "stage5":

                if (message4Appear == true && message5Appear == false)
                {
                    messageState = 5;
                    message5Appear = true;
                }
                break;
            case "stage6":
                if(message5Appear == true)
                {
                    messageState = 6;
                }
                break;
            case "stage7":
                if(withKey == true)
                {
                    messageState = 7;
                }
                break;

            case "End":
                Application.LoadLevel("Win");
                break;

        }
    }
}
