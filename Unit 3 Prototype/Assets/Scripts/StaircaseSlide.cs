using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseSlide : MonoBehaviour {

    public GameObject staircase;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Runner")
        {
            if(other.GetComponentInParent<PlayerMovement>().GetSliding())
            {
                staircase.GetComponentInChildren<BoxCollider>().enabled = false;
            }
        }
    }
}
