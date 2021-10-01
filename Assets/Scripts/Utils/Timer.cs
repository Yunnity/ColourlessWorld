using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    bool started = false;
    bool running = false;
    float elapsedSeconds;

    public bool IsFinished
    {
        get { return started && !running; }
    }

    public bool Running
    {
        get { return running; }
    }

    public float ElapsedSeconds
    {
        get { return elapsedSeconds; }
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            elapsedSeconds += Time.deltaTime;
        }
    }

    public void Run()
    {
        started = true;
        running = true;
    }

    public void Stop()
    {
        started = false;
        running = false;
        elapsedSeconds = 0;
    }
}
