using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    // This enum is used to determine the state of a node. It can be in one of three possible states.
    public enum State 
    {
        Running,
        Failure,
        Success
    }

    public State state = State.Running; // By default, the node will always run.
    public bool started = false; // By default, the node will not have started yet.
    public string gUID;
    public Vector2 pos;
    public State Update() // Returns the state of the node.
    {
        if (!started) 
        {
            OnStart();
            started = true;
        }

        state = OnUpdate();

        if (state == State.Failure|| state == State.Success) 
        {
            OnStop();
            started = false;
        }

        return state;
    }

    public virtual Node Clone() 
    {
        return Instantiate(this);
    }

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();
}
