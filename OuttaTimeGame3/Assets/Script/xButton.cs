using UnityEngine;
using System.Collections;

public class xButton : MonoBehaviour {

    float switchTime;
    float frameRate;
    SpriteRenderer sr;
    public Sprite buttonUp;
    public Sprite buttonDown;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        switchTime = 0.0f;
        frameRate = 0.0625f;

        if(sr.sprite == null)
        {
            sr.sprite = buttonUp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.sprite == buttonUp)
        {
            switchTime += Time.deltaTime;
            if (switchTime > frameRate)
            {
                sr.sprite = buttonDown;
                switchTime = 0.0f;
            }
        }

        else
        {
            switchTime += Time.deltaTime;
            if (switchTime > frameRate)
            {
                sr.sprite = buttonUp;
                switchTime = 0.0f;
            }
        }
    }
}
