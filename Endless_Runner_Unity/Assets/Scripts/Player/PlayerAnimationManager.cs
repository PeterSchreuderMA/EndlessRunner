using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour 
{

    private Animator animator;
    private InputState _inputState;

    // Use this for initialization
    void Awake () 
    {
        animator = GetComponent<Animator>();
        _inputState = GetComponent<InputState>();
    }

	
	
    // Update is called once per frame
    void Update () 
    {
        var running = true;

        if (_inputState.absVelX > 0 && _inputState.absVelY < _inputState.standingThreshold)
        {
            running = false;
        }

        //Set the running state to that of the var: running
        animator.SetBool("State_Running", running);
    }


}

