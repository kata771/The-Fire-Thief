using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float distanceToPlayer = 5f;
    [SerializeField] private int simultaneousSpawnCount = 3;
    [SerializeField] private float minDistanceBetweenObstacles = 1f;
    [SerializeField] private float maxDistanceBetweenObstacles = 3f;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float obstacleSpeed = 5f;

    private float lastSpawnPositionX;

    /// <summary>
    /// At the Start we do the initial spawn.
    /// </summary>
    private void Start()
    {
        SpawnObstacles();
    }

    /// <summary>
    /// In the Update we update positions and move obstacles (that basically fly from the right)
    /// </summary>
    private void Update()
    {
        //// Update the spawner position based on the player's movement
        //float targetSpawnPositionX = playerTransform.position.x + distanceToPlayer;

        //// Check if it's time to spawn a new set of obstacles
        //if (targetSpawnPositionX > lastSpawnPositionX)
        //{
        //    SpawnObstacles();
        //}

        // Move spawned obstacles towards the player
        MoveObstacles();
    }

    /// <summary>
    /// Method responsible for spawning obstacles.
    /// </summary>
    private void SpawnObstacles()
    {
        for (int i = 0; i < simultaneousSpawnCount; i++)
        {
            int randomObstacle = Random.Range(0, obstaclePrefabs.Length);
            int randomY = Random.Range(1, 8);  // Adjusted to include 9 as well

            // Generate a random offset for each obstacle on the X-axis
            float randomXOffset = Random.Range(minDistanceBetweenObstacles, maxDistanceBetweenObstacles);

            Vector3 spawnPosition = new Vector3(playerTransform.position.x + distanceToPlayer + randomXOffset, randomY, 0);

            GameObject newObstacle = Instantiate(obstaclePrefabs[randomObstacle], spawnPosition, Quaternion.identity);
            // Set the speed for the obstacle
            newObstacle.GetComponent<ObstacleMovement>().SetSpeed(obstacleSpeed);
        }

        // This method was supposed to destroy obstacles after time but I moved the logic to the obstalcemovement
        //StartCoroutine(DestroyObstaclesAfterTime(8f));

        // Reduce the time interval between spawns
        Invoke(nameof(SpawnObstacles), spawnInterval);
    }

    /// <summary>
    /// Method responsible for spawning obstacles.
    /// </summary>
    private void SpawnObstaclesOld()
    {
        for (int i = 0; i < simultaneousSpawnCount; i++)
        {
            int randomObstacle = Random.Range(0, obstaclePrefabs.Length);
            int randomY = Random.Range(1, 8);  // Adjusted to include 9 as well

            // Generate a random offset for each obstacle on the X-axis
            float randomXOffset = Random.Range(minDistanceBetweenObstacles, maxDistanceBetweenObstacles);

            Vector3 spawnPosition = new Vector3(lastSpawnPositionX + randomXOffset, randomY, 0);

            GameObject newObstacle = Instantiate(obstaclePrefabs[randomObstacle], spawnPosition, Quaternion.identity);
            // Set the speed for the obstacle
            newObstacle.GetComponent<ObstacleMovement>().SetSpeed(obstacleSpeed);
        }

        // Update lastSpawnPositionX only once after spawning the set of obstacles
        // TODO: Right now, since we dont die, when the player stands still, the obstacles start spawning
        // waaay to far and get destroyed before getting to player
        lastSpawnPositionX += maxDistanceBetweenObstacles + distanceToPlayer;

        // This method was supposed to destroy obstacles after time but I moved the logic to the obstalcemovement
        //StartCoroutine(DestroyObstaclesAfterTime(8f));

        // Reduce the time interval between spawns
        Invoke(nameof(SpawnObstaclesOld), spawnInterval);
    }

    /// <summary>
    /// Method responsible for moving obstacles
    /// </summary>
    private void MoveObstacles()
    {
        // Move all spawned obstacles towards the player on the -X axis
        GameObject[] newObstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in newObstacles)
        {
            obstacle.transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
        }
    }

    //private IEnumerator DestroyObstaclesAfterTime(float seconds)
    //{
    //    if (spawnedObstacles.Count <= 0) yield break;

    //    yield return new WaitForSeconds(seconds);

    //    if (spawnedObstacles.Count < 3)
    //    {
    //        foreach (GameObject g in spawnedObstacles)
    //        {
    //            Destroy(g);
    //        }
    //    }
    //    else
    //    {
    //        Destroy(spawnedObstacles[0]);
    //        Destroy(spawnedObstacles[1]);
    //        Destroy(spawnedObstacles[2]);
    //    }

    //    spawnedObstacles.Remove(spawnedObstacles[0]);
    //    spawnedObstacles.Remove(spawnedObstacles[1]);
    //    spawnedObstacles.Remove(spawnedObstacles[2]);
    //}
}