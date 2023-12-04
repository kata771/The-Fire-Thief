using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class defines the actions of GameObject Zeus 
/// </summary>
public class Zeus : MonoBehaviour
{
    private Rigidbody2D rb;
    private float initialVelocity = 1f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float timeToWait = 6f;
    private float timer;

    /// <summary>
    /// Start method gets the Rigidbody2D component attached to the GameObject, sets the initial velocity and initializes the timer
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.velocity = new Vector2(initialVelocity, 0f);
        timer = timeToWait;
    }

    /// <summary>
    /// Update method is increasing the velocity by 1f depending on the time elapsed. 
    /// </summary>
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            initialVelocity += acceleration;
            rb.velocity = new Vector2(initialVelocity, 0f);
            timer = timeToWait;
        }
    }

    /// <summary>
    /// Getter for the initial velocity
    /// </summary>
    /// <returns> Initial velocity as float </returns>
    public float GetInitialVelocity()
    {
        return initialVelocity;
    }

    /// <summary>
    /// Setter for the initial velocity
    /// </summary>
    /// <param name="newInitialVelocity"> Value for the new velocty </param>
    public void SetInitialVelocity(float newInitialVelocity)
    {
        initialVelocity = newInitialVelocity;
        rb.velocity = new Vector2(initialVelocity, 0f);
    }
}