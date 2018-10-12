using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMovement : MonoBehaviour 
{
    // Liniair speed in units per sec.
    public float XAxesSpeed = 0;
    public float YAxesSpeed = 0;
    public float ZAxesSpeed = 0;

    // Use this for initialization

    void Update()
    {
        //Set the new rotation
        Vector3 newPosition = new Vector3(transform.rotation.x + XAxesSpeed * Time.deltaTime, transform.rotation.y + YAxesSpeed * Time.deltaTime, transform.rotation.z + ZAxesSpeed * Time.deltaTime);
        //Set the new rotation to the current rotation
        //transform.rotation = Quaternion.Euler(newRotation);
        transform.Translate(newPosition);
    }

}

