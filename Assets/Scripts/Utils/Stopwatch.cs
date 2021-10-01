using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    float duration;
    bool started = false;
    bool running = false;
    float elapsedSeconds = 0;

    public float Duration
    {
        set
        {
            if(!running)
            {
                duration = value;
            }
        }
    }

    public float ElapsedSeconds
    {
        get { return elapsedSeconds; }
    }

    public bool Running
    {
        get { return running; }
    }

    public bool IsFinished
    {
        get { return started && !running; }
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= duration)
            {
                running = false;
            }
        }
    }

    public void Run()
    {
        if (duration > 0)
        {
            started = true;
            running = true;
        }
    }

    public void Stop()
    {
        running = false;
        started = false;
        elapsedSeconds = 0;
    }

    public void Pause()
    {
        running = false;
    }
}
