using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceJump : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("JUMP GOD DAMN YOU!");
        other.GetComponentInParent<PlayerMovement>().Jumping();
        other.GetComponentInParent<PlayerMovement>().SetJumping(true);
    }
}
