using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    /*
     * Delclaring Variables required for this method to run.
     * 
     * bool canJump returns true if the player can jump at any moment
     * bool canSlide returns true if the player can slide at any moment
     * bool jumping returns true if the player is currently in the action of jumping
     * bool gameStarted returns true after the player has started the game
     * bool sliding returns true if the player is currenty in the action of sliding
     * 
     * float lastHeight is used to determine if the player is in the act of jumping
     * float runningSpeed is the variable of the players right-to-screen speed-
     * float slideAmount is the variable to 'shrink' the player for a slide
     * 
     * int jumpAmount is the variable for how high the player can jump
     * in gravity is the variable given to bring the player back to ground
     * 
     * GameObject playerRunner is the object which is moved
     * 
     */
    bool canJump;
    bool canSlide;
    bool jumping;
    bool gameStarted;
    bool sliding;

    float lastHeight;
    float runningSpeed;
    public float slideAmount;

    public int jumpAmount;
    public int gravityAmount;

    Vector3 fullSize;

    public GameObject playerRunner;


    /*
     * void Start() is ran at the when the program is loaded
     * 
     * lastHeight is given the value of the GameObject as it currently stands
     * gameStarted is initialised as false until the players first input
     * jumping is initialised as false as the player is currently not jumping
     * sliding is initialised as false as the player is currently not sliding
     * 
     */
    void Start ()
    {
        lastHeight = playerRunner.transform.position.y;
        gameStarted = false;
        jumping = false;
        sliding = false;
        fullSize = playerRunner.transform.localScale;
    }
	
	/*
     * void Update() is run every frame
     * 
     * canJump is checked with the method CanJump which returns a true/false value
     * 
     * Next few are 'listening' to the players commands and excecute the following
     * If the Up Arrow is pressed & canJump is true
     *  call Jumping()
     * If the down arrow is pressed and canSlide is true
     *  call Sliding()
     * When the down arrow is released 
     * 
     * It also calls the methods Gravity() and Running() every frame
     * 
     */
	void Update ()
    {
        //canSlide = CanSlide(lastRotation);

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
            Jumping();

        if (Input.GetKeyDown(KeyCode.DownArrow) && canSlide)
            Sliding();

        if (Input.GetKeyDown(KeyCode.Space))
            gameStarted = true;

        if (Input.GetKeyUp(KeyCode.DownArrow))
            Stand();
        Gravity(jumping);
        Running();
        //Running(gameStarted);
    }

    /*
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
    */

    void Gravity(bool currentlyJumping)
    {
        if (currentlyJumping)
            transform.position = transform.position + new Vector3(0, (-gravityAmount * Time.deltaTime), 0);
    }

    void Jumping()
    {
        if (!jumping)
        {
            jumping = true;
            transform.position = transform.position + new Vector3(0, (jumpAmount * Time.deltaTime), 0);
        }
    }

    void Sliding()
    {
        transform.localScale = transform.localScale + (Vector3.one * -0.5f);
    }

    void Stand()
    {
        transform.localScale = fullSize;
    }

    void Running()
    {
        if (gameStarted)
        {
            runningSpeed = Time.deltaTime * 10;
            transform.position = transform.position + new Vector3(runningSpeed, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            jumping = false;
            canJump = true;
            canSlide = true;
        }

        if(other.tag == "Falling")
        {
            jumping = true;
            canJump = false;
            canSlide = false;
        }
    }
}
