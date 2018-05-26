using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float lastHeight;
    //float lastRotation;
    bool canJump;
    bool canSlide;
    bool jumping;
    //bool sliding;
    bool gameStarted;
    public GameObject playerRunner;
    public GameObject cameraControl;
    public int jumpAmount;
    public int rotateSpeed;
    public int gravityAmount;
    float runningSpeed;

	// Use this for initialization
	void Start ()
    {
        lastHeight = playerRunner.transform.position.y;
        //lastRotation = playerRunner.transform.rotation.z;
        jumping = false;
        //sliding = false;
        gameStarted = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        canJump = CanJump(lastHeight);
        //canSlide = CanSlide(lastRotation);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jumping();

        if (Input.GetKeyDown(KeyCode.DownArrow) && canSlide)
            Sliding();
        if (Input.GetKeyUp(KeyCode.DownArrow))
            Stand();
        if (Input.GetKeyDown(KeyCode.Space))
            gameStarted = true;
        Gravity(jumping);
        Running(gameStarted);
    }

    bool CanJump(float lHeight)
    {
        float currentHeight = playerRunner.transform.position.y;
        if (currentHeight == lHeight)
        {
            lastHeight = currentHeight;
            jumping = false;
            return true;
        }
        else
        {
            lastHeight = currentHeight;
            jumping = true;
            return false;
        }
    }

   /*bool CanSlide(float lRotation)
    {
        float currentRoation;
    }*/


    void Gravity(bool currentlyJumping)
    {
        if(currentlyJumping)
            playerRunner.GetComponent<Rigidbody>().AddForce(Vector3.down * gravityAmount);
    }
    
    void Jumping()
    {
        playerRunner.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpAmount);
    }

    void Sliding()
    {
        //playerRunner.GetComponent<Rigidbody>().isKinematic = true;
        //playerRunner.GetComponent<Rigidbody>().AddTorque(Vector3.forward * rotateSpeed * Time.deltaTime);
        //playerRunner.GetComponent<Rigidbody>().AddTorque(Vector3.forward * rotateSpeed);
        playerRunner.transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        Debug.Log(playerRunner.transform.rotation.z);

        if (playerRunner.transform.rotation.z > 0.5f)
            canSlide = false;
        else
            Sliding();

    }

    void Stand()
    {
        playerRunner.transform.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
        Debug.Log(playerRunner.transform.rotation.z);

        if (playerRunner.transform.rotation.z < 0.01f)
        {
            canSlide = true;
            //playerRunner.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
            Stand();
    }

    void Running(bool hasStarted)
    {
        if(hasStarted)
        {
            runningSpeed = Time.deltaTime * 10;
            transform.position = transform.position + new Vector3(runningSpeed, 0, 0);
        }
    }
}
/*
float zRot = playerRunner.transform.rotation.z;
        if (zRot != 0.6f)
        {
            playerRunner.GetComponent<Rigidbody>().AddTorque(Vector3.forward * rotateSpeed);
            Sliding();
        }
        Debug.Log(playerRunner.transform.rotation.z);
        
playerRunner.GetComponent<Rigidbody>().isKinematic = true;
float zRot = playerRunner.transform.rotation.z;
while (zRot > 0.5f)
{
    playerRunner.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    //playerRunner.GetComponent<Rigidbody>().AddTorque(Vector3.forward * rotateSpeed * Time.deltaTime);
    Debug.Log(playerRunner.transform.rotation.z);
    //Sliding();
}

playerRunner.GetComponent<Rigidbody>().isKinematic = true;
        playerRunner.GetComponent<Rigidbody>().AddTorque(Vector3.forward* rotateSpeed);
        while (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
        }
        
     
     
*/
