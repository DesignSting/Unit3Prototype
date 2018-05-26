using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour {

    public int duration = 30;
    public int timeRemaining;
    public bool isCountingDown = false;

    private void Start()
    {
        Begin();
    }

    public void Begin()
    {
        if(!isCountingDown)
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
            isCountingDown = false;
    }
}
