using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class defines the actions of GameObject Zeus 
/// </summary>
public class Zeus : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float initialVelocity = 1f;
    private float acceleration = 1f;
    private float timeToWait = 6f;
    private float timer;

    /// Start method gets the Rigidbody2D component attached to the GameObject, sets the initial velocity and initializes the timer
    /// Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {

            rigidBody = gameObject.AddComponent<Rigidbody2D>();
        }
        rigidBody.velocity = new Vector2(initialVelocity, 0f);
        timer = timeToWait;
    }

    /// Update method is increasing the velocity by 1f depending on the time elapsed. 
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            initialVelocity += acceleration;
            rigidBody.velocity = new Vector2(initialVelocity, 0f);
            timer = timeToWait;
        }

    }

   /// getters and setters of the class 
    public float GetInitialVelocity()
    {
        return initialVelocity;
    }

    public void SetInitialVelocity(float newInitialVelocity)
    {
        initialVelocity = newInitialVelocity;
        rigidBody.velocity = new Vector2(initialVelocity, 0f);
    }
}