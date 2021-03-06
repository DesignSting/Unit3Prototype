﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    public GameObject playerRunner;
    public GameObject cameraController;

    private int newSpeed = 15;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Runner")
        {
            other.GetComponentInParent<PlayerMovement>().ChangeSpeed(newSpeed);
            cameraController.GetComponentInParent<CameraController>().ChangeSpeed(newSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Runner")
        {
            other.GetComponentInParent<PlayerMovement>().ChangeSpeed();
            cameraController.GetComponentInParent<CameraController>().ChangeSpeed();
        }
    }
}
