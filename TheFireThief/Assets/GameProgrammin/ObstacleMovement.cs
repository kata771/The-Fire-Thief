using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that represents each obstacle.
/// </summary>
public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    /// <summary>
    /// At the Start we already define when the object would get destroyed after flying.
    /// </summary>
    private void Start()
    {
        Invoke(nameof(DestroyAfterTime), 8f); // ^
    }

    /// <summary>
    /// Method for setting the speed for the obstacle
    /// </summary>
    /// <param name="newSpeed"> New Speed </param>
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    /// <summary>
    /// In update we move the object.
    /// </summary>
    void Update()
    {
        // Move the obstacle on the -X axis
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    /// <summary>
    /// Simple method that destroys an object.
    /// </summary>
    private void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}