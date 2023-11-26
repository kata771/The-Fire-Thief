using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] private Transform[] obstacle;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float distanceToPlayer = 5f; // Adjust as needed
    [SerializeField] private int simultaneousSpawnCount = 3; // Adjust as needed
    [SerializeField] private float minDistanceBetweenObstacles = 1f; // Minimum distance between obstacles
    [SerializeField] private float maxDistanceBetweenObstacles = 3f; // Maximum distance between obstacles
    [SerializeField] private float spawnInterval = 1f; // Adjust as needed
    [SerializeField] private float obstacleSpeed = 5f; // Adjust the speed as needed

    private float lastSpawnPositionX;

    private void Start()
    {
        // Initial spawn
        SpawnObstacles();
    }

    private void Update()
    {
        // Update the spawner position based on the player's movement
        float targetSpawnPositionX = playerTransform.position.x + distanceToPlayer;

        // Check if it's time to spawn a new set of obstacles
        if (targetSpawnPositionX > lastSpawnPositionX)
        {
            SpawnObstacles();
        }

        // Move spawned obstacles towards the player
        MoveObstacles();
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < simultaneousSpawnCount; i++)
        {
            int randomObstacle = Random.Range(0, obstacle.Length);
            int randomY = Random.Range(1, 8);  // Adjusted to include 9 as well

            // Generate a random offset for each obstacle on the X-axis
            float randomXOffset = Random.Range(minDistanceBetweenObstacles, maxDistanceBetweenObstacles);

            Vector3 spawnPosition = new Vector3(lastSpawnPositionX + randomXOffset, randomY, 0);

            Transform newObstacle = Instantiate(obstacle[randomObstacle], spawnPosition, Quaternion.identity);
            // Set the speed for the obstacle
            newObstacle.GetComponent<ObstacleMovement>().SetSpeed(obstacleSpeed);
        }

        // Update lastSpawnPositionX only once after spawning the set of obstacles
        lastSpawnPositionX += maxDistanceBetweenObstacles + distanceToPlayer;

        // Reduce the time interval between spawns
        Invoke("SpawnObstacles", spawnInterval);
    }

    private void MoveObstacles()
    {
        // Move all spawned obstacles towards the player on the -X axis
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
        }
    }
}