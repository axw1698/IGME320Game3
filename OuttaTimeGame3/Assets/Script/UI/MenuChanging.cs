using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuChanging : MonoBehaviour {

    public Texture[] image;
    public bool ifMenuChange = false;
    int counter = 0;
    GameObject text;
    // Use this for initialization
    void Start () {
        text = GameObject.Find("Text");
        if (ifMenuChange == true)
        {
            text.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (ifMenuChange == true)
        {
            this.gameObject.GetComponent<RawImage>().texture = image[counter];

            if (counter == 16)
            {
                text.SetActive(true);

            }
        }
    }

    public void changePage()
    {
        if (counter == 16)
        {
            Application.LoadLevel("instructions");

        }
        else
        {
            counter++;
        }
    }

    public void startGame()
    {
        Application.LoadLevel("graveYardGamePlay");
    }


}
