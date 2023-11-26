using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed;

    // Set the speed for the obstacle
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        // Move the obstacle on the -X axis
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}