using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTRunner : MonoBehaviour
{
    BehaviorTree bT; // The behavior tree intended to run.
    
    // Start is called before the first frame update
    void Start()
    {
        bT = bT.Clone();
    }

    // Update is called once per frame
    void Update()
    {
        bT.Update();
    }
}
