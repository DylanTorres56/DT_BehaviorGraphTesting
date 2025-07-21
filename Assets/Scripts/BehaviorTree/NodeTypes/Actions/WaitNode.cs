using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode : ActionNode
{
    public float duration = 1; // The duration, in seconds, of the delay before the next node fires.
    float startTime; // The time this node was called.

    protected override void OnStart()
    {
        startTime = Time.time;
    }

    protected override void OnStop()
    {
        
    }

    // If the duration has been met, the Wait node returns successful. Otherwise, it is still running.
    protected override State OnUpdate()
    {
        if (Time.time - startTime > duration) 
        {
            return State.Success;
        }
        return State.Running;
    }

}
