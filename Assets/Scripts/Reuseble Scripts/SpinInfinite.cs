using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinInfinite : MonoBehaviour 
{
    // Angular speed in radians per sec.
    public float XAxesSpeed = 0;
    public float YAxesSpeed = 0;
    public float ZAxesSpeed = 0;

    void FixedUpdate()
    {
        //Set the new rotation
        Vector3 newRotation = new Vector3(transform.rotation.x + XAxesSpeed * Time.deltaTime, transform.rotation.y + YAxesSpeed * Time.deltaTime, transform.rotation.z + ZAxesSpeed * Time.deltaTime);
        //Set the new rotation to the current rotation
        //transform.rotation = Quaternion.Euler(newRotation);
        transform.Rotate(newRotation);
    }
}

