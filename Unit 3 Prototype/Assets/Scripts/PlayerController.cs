using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float currentHeight;
    float lastHeight;
    bool canJump = false;
    public GameObject playerRunner;

	// Use this for initialization
	void Start ()
    {
        lastHeight = playerRunner.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentHeight = playerRunner.transform.position.y;
		if(currentHeight != lastHeight)
        {
            canJump = false;
        }
	}

    bool CanJump()
    {
        
        return true;
    }
}
