using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrRotateTowards : MonoBehaviour
{
    // The target marker.
    public Transform target;

    // Angular speed in radians per sec.
    public float speed = 1;

    void Update()
    {


        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);


        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        eulerAngles.y = eulerAngles.y-90;

        // Set the altered rotation back
        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}