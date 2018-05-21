using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject flyingBox;
    private bool isStartGame = false;
    private bool hasStartedGame = false;
    float startPosition;
    private float translation;

    public int duration = 30;
    public int timeRemaining;
    public bool isCountingDown = false;

    // Use this for initialization
    void Start ()
    {
        startPosition = flyingBox.transform.position.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //float translation = Time.deltaTime * 10;
        //transform.position = transform.position + new Vector3(translation, 0, 0);
        //transform.position = transform.position + new Vector3(0.1f, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space) && !hasStartedGame)
        {
            isStartGame = true;
            Debug.Log("Space is Down");
            Begin();
            hasStartedGame = true;
        }

        if(isStartGame && !isCountingDown)
        {
            SideCameraControl();
        }
	}

    void SideCameraControl()
    {
         translation = Time.deltaTime * 10;
         transform.position = transform.position + new Vector3(translation, 0, 0);

        if(flyingBox.transform.position.x >= 60)
        {
            isStartGame = false;
        }
    }

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
}
