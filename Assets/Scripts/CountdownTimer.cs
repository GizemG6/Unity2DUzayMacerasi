using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    float totalTime = 0;
    float passingTime = 0;
    bool working = false;
    bool started = false;
    /// <summary>
    /// sets the total time of the counter
    /// </summary>
    public float TotalTime
    {
        set
        {
            if (!working)
            {
                totalTime = value;
            }
        }
    }
    /// <summary>
    /// value returns when finished
    /// </summary>
    public bool Finished
    {
        get
        {
            return started && !working;

        }
    }
    /// <summary>
    /// runs timer
    /// </summary>
    public void Work()
    {
        if (totalTime > 0)
        {
            working = true;
            started = true;
            passingTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (working)
        {
            passingTime += Time.deltaTime;
            if (passingTime >= totalTime)
            {
                working = false;
            }
        }
    }
}
