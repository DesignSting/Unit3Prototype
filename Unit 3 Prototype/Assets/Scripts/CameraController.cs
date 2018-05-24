using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject flyingBox;
    public GameObject groundControl;
    private bool hasStartedGame = false;
    private float translation;
    public int movementSpeed;

    public float duration = 30;
    public float timePassed;

    public bool isCountingDown = false;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        //float translation = Time.deltaTime * 10;
        //transform.position = transform.position + new Vector3(translation, 0, 0);
        //transform.position = transform.position + new Vector3(0.1f, 0, 0);

        Count(hasStartedGame);

        if (Input.GetKeyDown(KeyCode.Space) && !hasStartedGame)
        {
            timePassed = 0;
            hasStartedGame = true;
            SideCameraControl();
        }

        if (timePassed >= duration)
            hasStartedGame = false;


        if (hasStartedGame && isCountingDown)
        {
            SideCameraControl();
        }
	}

    void SideCameraControl()
    {
        isCountingDown = true;
        translation = Time.deltaTime * movementSpeed;
        transform.position = transform.position + new Vector3(translation, 0, 0);
    }

    public void Count(bool gameStarted)
    {
        if(gameStarted)
            timePassed += Time.deltaTime;
    }

    /*
    public void Begin()
    {
        if (!isCountingDown)
        {
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
    }

    private void _tick()
    {
        Debug.Log(timeRemaining);
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", 1f);
        }
        else
            isCountingDown = true;
    }

    private int TimeRemaining()
    {
        return timeRemaining;
    }

    */
}
