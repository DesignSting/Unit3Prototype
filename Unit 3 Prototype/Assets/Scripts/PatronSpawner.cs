using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronSpawner : MonoBehaviour {

    public GameObject patronToSpawn;


	// Use this for initialization
	void Start ()
    {
        Instantiate(patronToSpawn);
	}
	
}
