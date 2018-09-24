using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour 
{

    public float jumpSpeed = 240f;
    public float forwardSpeed = 20;

    private Rigidbody2D body2d;
    private InputState _inputState;
	

// Use this for initialization
void Start () 
{
    body2d = GetComponent<Rigidbody2D>();
    _inputState = GetComponent<InputState>();
}

	
	
// Update is called once per frame
void Update () 
{
	if (_inputState.standing)
    {
        if (_inputState.actionButton)
        {//Make the player jump if any button is pressed. And laways make the player move to the center of the screen when standing on objects
            body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed);
        }
    }

}

}

