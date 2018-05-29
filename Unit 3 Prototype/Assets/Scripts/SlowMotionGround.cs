using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionGround : MonoBehaviour {

    public GameObject playerRunner;
    public GameObject cameraController;

    private int newSpeed = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Runner")
        {
            other.GetComponentInParent<PlayerMovement>().SetJumping(true);
            other.GetComponentInParent<PlayerMovement>().ChangeSpeed(newSpeed);
            cameraController.GetComponentInParent<CameraController>().ChangeSpeed(newSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Runner")
        {
            other.GetComponentInParent<PlayerMovement>().SetJumping(false);
            other.GetComponentInParent<PlayerMovement>().ChangeSpeed();
            cameraController.GetComponentInParent<CameraController>().ChangeSpeed();
        }
    }
}
