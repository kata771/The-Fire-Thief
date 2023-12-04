using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a manager for the powerups that are used in the game.
/// </summary>
public class PowerUpManager : MonoBehaviour
{
    // [SerializeField] is used so I could assign values from the Editor.
    [SerializeField] private GameObject[] powerUpPrefabs; 
    [SerializeField] private float spawnDistance = 5f;
    [SerializeField] private float minSpawnInterval = 2f;
    [SerializeField] private float maxSpawnInterval = 5f;
    [SerializeField] private float minYPosition = 2f;
    [SerializeField] private float maxYPosition = 4f;
    [SerializeField] private Transform player;
    [SerializeField] private Transform zeus;

    private float nextSpawnTime;

    /// <summary>
    /// In the Start method we calculate the initial nextSpawnTime for the powerup.
    /// </summary>
    private void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    /// <summary>
    /// Main method where we do all the calculations regarding which, when and what powerup should spawn.
    /// After it is instantiated, we assign player and zeus gameobjects to it for future interactions.
    /// </summary>
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            int indexPowerUp = Random.Range(0, powerUpPrefabs.Length);
            GameObject selectedPowerUpPrefab = powerUpPrefabs[indexPowerUp];
            float randomYPosition = Random.Range(minYPosition, maxYPosition);
            Vector3 v = new Vector3(spawnDistance, randomYPosition, 0f);
            Vector3 spawnPosition = player.position + v;
            GameObject spawnedPowerUp = Instantiate(selectedPowerUpPrefab, spawnPosition, Quaternion.identity);
            PowerUp powerUp = spawnedPowerUp.GetComponent<PowerUp>(); // ^
            powerUp.SetPlayer(player.gameObject); // ^
            powerUp.SetZeus(zeus.gameObject); // ^
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }
}
