using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerNode : CompositeNode
{
    int currentChild; // The current child node meant to be executed in the list.

    // Execute each child node in order from the beginning index.
    protected override void OnStart()
    {
        currentChild = 0;
    }

    protected override void OnStop()
    {

    }

    // Execute the child nodes from the beginning of the children node list to the end. If even one fails, the task fails.
    protected override State OnUpdate()
    {
        var child = children[currentChild];
        switch (child.Update())
        {
            case State.Running:
                return State.Running;                
            case State.Failure:
                return State.Failure;
            case State.Success:
                currentChild++;
                break;
        }

        // After the switch statement, return the currentChild. If all children have been executed, the sequence has succeeded. If not, it is still running.
        return currentChild == children.Count ? State.Success : State.Running;
    }

}
