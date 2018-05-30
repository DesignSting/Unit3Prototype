using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    /*
     * Delclaring Variables required for this method to run.
     * 
     * bool canJump returns true if the player can jump at any moment
     * bool canSlide returns true if the player can slide at any moment
     * bool jumping returns true if the player is currently in the action of jumping
     * bool gameStarted returns true after the player has started the game
     * bool sliding returns true if the player is currenty in the action of sliding
     * bool isGrounded returns true if the collision on the player is with a ground tag
     * bool phaseThrough returns true if currently behind a table
     * 
     * float lastHeight is used to determine if the player is in the act of jumping
     * float runningSpeed is the variable of the players right-to-screen speed
     * float slideAmount is the variable to 'shrink' the player for a slide
     * 
     * int duration is simply a counter for how long the game is played
     * int jumpAmount is the variable for how high the player can jump
     * int gravityAmount is the variable given to bring the player back to ground, artifical gravity
     * int movementSpeed is the multiplier to form the runningSpeed
     * int tipsHeld is the current amount of tips help by the player
     * 
     * GameObject playerControl is the object which is moved
     * 
     */
    bool canJump;
    bool canSlide;
    bool jumping;
    bool gameStarted;
    public bool sliding;
    bool isGrounded;
    bool phaseThrough;
    bool forceSlide;

    float runningSpeed;
    public float slideAmount;
    public float timePassed;

    public float duration = 30;
    public int jumpAmount;
    public int gravityAmount;
    public int movementSpeed;
    private int defaultSpeed;
    private int tipsHeld;
    private int drinksHeld;

    public GameObject playerControl;
    public GameObject runningPlayer;
    public GameObject slidingPlayer;
    public GameObject currentPatron;
    public GameObject cameraControl;

    private Rigidbody rb;


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
        gameStarted = false;
        jumping = false;
        sliding = false;
        slidingPlayer.SetActive(false);
        runningPlayer.SetActive(true);
        isGrounded = false;
        defaultSpeed = 15;
        movementSpeed = defaultSpeed;
        rb = GetComponentInChildren<Rigidbody>();
        canSlide = false;
        forceSlide = false;
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
     * 
     * It also calls the methods Gravity() and Running() every frame
     * 
     */
	void Update ()
    {
        //canSlide = CanSlide(lastRotation);
        //Count(gameStarted);

        if (Input.GetKeyDown(KeyCode.UpArrow) && !sliding)
            Jumping();

        if (Input.GetKeyDown(KeyCode.DownArrow) && !jumping)
            Sliding();

        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            GameStart();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !forceSlide)
            Stand();

        if (timePassed >= duration)
        {
            gameStarted = false;
        }

        if (Input.GetKeyUp(KeyCode.R))
            SceneManager.LoadScene(0);

        Gravity(jumping);
        Running();
        //Running(gameStarted);
    }

    /*
    bool CanJump(float lHeight)
    {
        float currentHeight = playerControl.transform.position.y;
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
        /*
        if (currentlyJumping)
        {
            transform.position = transform.position + new Vector3(0, (-gravityAmount * Time.deltaTime), 0);
        }
        */
        if (!currentlyJumping)
            gravityAmount = 40;

        if(currentlyJumping)
        {

            rb.AddForce(Vector3.down * gravityAmount);
            gravityAmount++;
        }
        
    }

    public void Jumping()
    {
        /*if (!jumping)
        {
            jumping = true;
            transform.position = transform.position + new Vector3(0, (jumpAmount * Time.deltaTime), 0);
        }
        */
        if(!jumping)
        {
            jumping = true;
            rb.velocity = Vector3.up * jumpAmount;
        }
    }

    public void Sliding()
    {
        sliding = true;
        slidingPlayer.SetActive(true);
        runningPlayer.SetActive(false);
    }

    public void Sliding(bool slide)
    {
        forceSlide = true;
        SetJumping(true);
        Sliding();
    }

    public void Stand()
    {
        sliding = false;
        runningPlayer.SetActive(true);
        slidingPlayer.SetActive(false);
        canSlide = true;
    }

    public void Stand(bool stand)
    {
        forceSlide = false;
        SetJumping(false);
        Stand();
    }

    void GameStart()
    {
        runningSpeed = Time.deltaTime * movementSpeed;
        transform.position = transform.position + new Vector3(runningSpeed, 0, 0);
        jumping = true;
        transform.position = transform.position + new Vector3(0, (200 * Time.deltaTime), 0);
        gameStarted = true;
        timePassed = 0;
    }

    public void Running()
    {
        if (gameStarted)
        {
            runningSpeed = Time.deltaTime * movementSpeed;
            transform.position = transform.position + new Vector3(runningSpeed, 0, 0);
        }
    }

    public void ChangeSpeed()
    {
        movementSpeed = defaultSpeed;
        //cameraControl.AddComponent<CameraController>().ChangeSpeed();
    }
    public void ChangeSpeed(int newSpeed)
    {
        jumping = false;
        movementSpeed = newSpeed;
        //cameraControl.get
    }

    public void AddTips(int toAdd)
    {
        tipsHeld += toAdd;
        Debug.Log("Tips Held: " + tipsHeld);
    }

    public void AddDrink(int toAdd)
    {
        drinksHeld += toAdd;
    }

    public void SubDrinks()
    {
        --drinksHeld;
    }

    public int ShowDrinks()
    {
        return drinksHeld;
    }

    public bool PhaseThrough()
    {
        return phaseThrough;
    }

    public void SetJumping(bool jump)
    {
        jumping = jump;
    }

    public void Climb()
    {
        float climbingSpeed = Time.deltaTime * 20;
        transform.position = transform.position + new Vector3(0, climbingSpeed, 0);
    }
    public void StopClimb()
    {
        transform.position = transform.position + new Vector3(0, 0, 0);
        Running();
    }
    public bool GetSliding()
    {
        return sliding;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ground")
        {
            isGrounded = true;
            jumping = false;
        }

        if (other.tag == "TableTop")
        {
            if (!phaseThrough)
            {
                jumping = false;
            }
            else
                jumping = true;
        }

        if (other.tag == "Falling")
        {
            if (!isGrounded)
                jumping = false;
            else
                jumping = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Table")
        {
            phaseThrough = true;
        }

        if (other.tag == "Ground")
        {
            isGrounded = true;
            jumping = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Table")
            phaseThrough = false;
    }


   /* 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Patron")
        {
            //tipsHeld += other.GetComponentInChildren<Patron>().sendTips();
            tipsHeld += other.GetComponent<Patron>().sendTips();
            //Debug.Log(tipsHeld);
        }
    }
    
    public void Count(bool gameStarted)
    {
        if (gameStarted)
            timePassed += Time.deltaTime;
    }
    */
}
