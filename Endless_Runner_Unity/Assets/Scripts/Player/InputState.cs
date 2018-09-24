﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {

    public bool actionButton;
    public float absVelX = 0f;
    public float absVelY = 0f;

    public bool standing;
    public float standingThreshold = 1;

    private Rigidbody2D body2d;

    // Use this for initialization
    void Awake ()
    {
        body2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        actionButton = Input.anyKeyDown;
	}

    //Calculate the absolute value of the players velocity
    void FixedUpdate()
    {//Check standing in the most simple way (Need to change this to the collider way)
        absVelX = System.Math.Abs(body2d.velocity.x);
        absVelY = System.Math.Abs(body2d.velocity.y);

        standing = absVelY <= standingThreshold;
    }
}