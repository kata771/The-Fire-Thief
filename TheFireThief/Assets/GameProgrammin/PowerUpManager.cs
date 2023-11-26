using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpPrefabs; 
    [SerializeField] private float spawnDistance = 5f;
    [SerializeField] private float minSpawnInterval = 2f;
    [SerializeField] private float maxSpawnInterval = 5f;
    [SerializeField] private float minYPosition = 2f;
    [SerializeField] private float maxYPosition = 4f;
    [SerializeField] private Transform player;

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            int indexPowerUp = Random.Range(0, powerUpPrefabs.Length);
            GameObject selectedPowerUpPrefab = powerUpPrefabs[indexPowerUp];
            float randomYPosition = Random.Range(minYPosition, maxYPosition);
            Vector3 v = new Vector3(spawnDistance, randomYPosition, 0f);
            Vector3 spawnPosition = player.position + v;
            Instantiate(selectedPowerUpPrefab, spawnPosition, Quaternion.identity);
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }
}
