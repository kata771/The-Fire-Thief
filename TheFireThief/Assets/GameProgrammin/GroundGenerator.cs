using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is rensponsible for generating path/ground for the player to move on.
/// </summary>
public class GroundGenerator : MonoBehaviour
{
     public Transform[] grounds;
     public Vector3 generatingNewPosition;

     public float generatingDistance;
     public float deletingDistance;
     public Transform prometheus;
    
    /// <summary>
    /// In Update we generate the ground if it is possible.
    /// </summary>
    void Update()
    {
        // Checking for the distance between player and last placed ground.
        // If the distance is lower than generating distance, we create and object
        while (Vector2.Distance(prometheus.transform.position, generatingNewPosition) < generatingDistance)
        {
            // We choose random ground to generate
            Transform randomGround = grounds[Random.Range(0, grounds.Length)];

            // Random preferred position
            Vector2 preferredPosition = new Vector2(generatingNewPosition.x - randomGround.Find("StartPosition").position.x, 0);

            // Spawned ground
            Transform selectedGrounds = Instantiate(randomGround, preferredPosition, transform.rotation, transform);

            // Save generating position for the next ground
            generatingNewPosition = selectedGrounds.Find("EndPosition").position;

        }
        DeletingGroundParts();
    }

    /// <summary>
    /// Method responsible for deleting ground elements outside of the player's view
    /// </summary>
    private void DeletingGroundParts()
    {
        if (transform.childCount > 0)
        {
            Transform deletingGround = transform.GetChild(0);

            if(Vector2.Distance(prometheus.transform.position, deletingGround.transform.position) > deletingDistance)

            Destroy(deletingGround.gameObject);
        }
    }
}
