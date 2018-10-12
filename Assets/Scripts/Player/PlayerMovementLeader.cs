using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLeader : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public float forwardSpeed = 10;


    private int Lanes;

    private InputState _inputState;


    private Rigidbody _rb3d;

    private void Start()
    {
        _rb3d = GetComponent<Rigidbody>();

        _inputState = GetComponent<InputState>();

        //Get the value of Lanes from the chunks
        Lanes = GameObject.Find("ChunkManager").GetComponent<ChunkCreator>().Lanes;
    }




    private void Update()
    {
        #region - Update Variables -

        //var GoToPointPos = DebugPlayerMovementLeader.transform.position;

        #endregion


        #region - Auto Movement -

        transform.position = new Vector3(transform.position.x + forwardSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //var velocity = Vector3.right * forwardSpeed;
        //_rb3d.MovePosition(_rb3d.position + velocity * Time.deltaTime);

        //DebugPlayerMovementLeader_rb3d.transform.position = new Vector3(transform.position.x, GoToPointPos.y, GoToPointPos.z);

        #endregion

        #region - Player Movement -

        if (forwardSpeed > 0)
        {
            if (_inputState.LeftButton)//Go Left
            {
                GoLeft();
            }


            if (_inputState.RightButton)//GO Right
            {
                GoRight();
            }
        }
            //transform.position = new Vector3.Lerp()

            #endregion

            #region - Jump - DA.

            //if (_inputState.grounded)
            //{
            //    if (_inputState.JumpButton)
            //    {
            //        //Make the player jump if any button is pressed. And laways make the player move to the center of the screen when standing on objects
            //        //_rb3d.velocity = new Vector3(transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed, transform.position.z);
            //        _rb3d.velocity = new Vector3(transform.position.x, jumpSpeed, transform.position.z);
            //    }
            //}

            #endregion
    }

    public void GoLeft()
    {
        if (transform.position.z != Lanes / 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
    }

    public void GoRight()
    {
        if (transform.position.z != -Lanes / 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
    }
}