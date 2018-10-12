using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {

    public bool JumpButton;
    public bool LeftButton;
    public bool RightButton;
    public bool ShootButton;
    //public 

    public float absVelX = 0f;
    public float absVelY = 0f;

    public bool grounded;
    public float standingThreshold = 1;

    private Rigidbody body2d;

    // Use this for initialization
    void Awake ()
    {
        body2d = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        JumpButton = Input.GetKeyDown(KeyCode.Space);

        LeftButton = Input.GetKeyDown(KeyCode.LeftArrow);

        RightButton = Input.GetKeyDown(KeyCode.RightArrow);

        ShootButton = Input.GetKeyDown(KeyCode.X);
    }

    //Calculate the absolute value of the players velocity
    void FixedUpdate()
    {


        //Check standing in the most simple way (Need to change this to the collider way)

        /*absVelX = System.Math.Abs(body2d.velocity.x);

        absVelY = System.Math.Abs(body2d.velocity.y);

        grounded = absVelY <= standingThreshold;*/
    }
}
