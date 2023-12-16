using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (transform.position == target)
        {
            // Change the target position to the other point
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }
}
