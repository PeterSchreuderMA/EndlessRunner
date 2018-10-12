using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSide : MonoBehaviour 
{

    public float jumpSpeed = 240f;
    public float forwardSpeed = 20;

    private InputState _inputState;
	

// Use this for initialization
void Start () 
{
    _inputState = GetComponent<InputState>();
}

	
	
// Update is called once per frame
void Update () 
{
	if (_inputState.grounded)
    {
        /*if (_inputState.JumpButton)
        {
            //Make the player jump if any button is pressed. And laways make the player move to the center of the screen when standing on objects
            body2d.velocity = new Vector3(transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed,);
        }*/
    }

}

}

