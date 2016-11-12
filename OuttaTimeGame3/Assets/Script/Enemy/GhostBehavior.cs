using UnityEngine;
using System.Collections;

public class GhostBehavior : MonoBehaviour {
    bool banished;
    public int radius;
    Vector3 distanceToTorch;
    Vector3 offset;
    GameObject torch;
    AudioSource scream;
    float floor; // the maximum distance the ghost travels before it leaves

	// Use this for initialization
	void Start () {
        banished = false;
        torch = GameObject.Find("Torch");
        floor = -60.0f;
        offset = new Vector3(0, 0.3f, 0);
        scream = GetComponent<AudioSource>();
        scream.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        CheckForTorch();

        if(banished)
        {
            Flee();
        }
	}

    void CheckForTorch()
    {
        distanceToTorch = torch.transform.position - transform.position;

        if(distanceToTorch.magnitude < radius)
        {
            banished = true;
            scream.Play();
        }
    }

    void Flee()
    {
        gameObject.transform.position -= offset;

        if(transform.position.y < floor)
        {
            Destroy(this.gameObject);
        }
    }
}
