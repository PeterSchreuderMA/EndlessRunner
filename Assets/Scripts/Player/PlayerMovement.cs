using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    private float forwardSpeed;

    void Start()
    {
        forwardSpeed = GameObject.Find("PlayerMoveLeader").GetComponent<PlayerMovementLeader>().forwardSpeed;
    }

    // Follows the target position like with a spring
    void Update()
    {
        forwardSpeed = GameObject.Find("PlayerMoveLeader").GetComponent<PlayerMovementLeader>().forwardSpeed;
        float step = 0;
        
            step = Mathf.Lerp(startMarker.position.z, endMarker.position.z, 5f * Time.deltaTime);           

        transform.position = new Vector3(transform.position.x + forwardSpeed * Time.deltaTime, transform.position.y, step);


    }
}