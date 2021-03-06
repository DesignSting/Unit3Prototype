﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableControl : MonoBehaviour {

    public GameObject tableTop;
    public GameObject playerRunner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Runner")
        {
            if(playerRunner.GetComponent<PlayerMovement>().PhaseThrough() == false)
            {
                tableTop.GetComponentInChildren<BoxCollider>().enabled = true;
                other.GetComponentInParent<PlayerMovement>().SetJumping(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Runner")
        {
            tableTop.GetComponentInChildren<BoxCollider>().enabled = false;
            /*if (playerRunner.GetComponent<PlayerMovement>().PhaseThrough() == false)
                other.GetComponentInParent<PlayerMovement>().SetJumping(true);*/
        }
    }
}
