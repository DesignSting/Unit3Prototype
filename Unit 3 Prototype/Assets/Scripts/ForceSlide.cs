using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSlide : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Runner")
        {
            other.GetComponentInParent<PlayerMovement>().Sliding(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Runner")
        {
            other.GetComponentInParent<PlayerMovement>().Stand(true);
        }
    }
}
