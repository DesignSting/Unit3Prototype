using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTrigger : MonoBehaviour {

    public GameObject cameraController;

    private int newSpeed = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Runner")
        {
            other.GetComponentInParent<PlayerMovement>().ChangeSpeed(newSpeed);
            other.GetComponentInParent<PlayerMovement>().Climb();
            cameraController.GetComponentInParent<CameraController>().ChangeSpeed(newSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Runner")
        {
            other.GetComponentInParent<PlayerMovement>().ChangeSpeed();
            other.GetComponentInParent<PlayerMovement>().StopClimb();
            other.GetComponentInParent<PlayerMovement>().SetJumping(true);
            cameraController.GetComponentInParent<CameraController>().ChangeSpeed();
        }
    }
}
