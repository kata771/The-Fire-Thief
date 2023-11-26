using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public GameObject cluePrefab;
    public float spawnDistance = 10f;
    public float minHeight = 2f;
    public float maxHeight = 4f;
    [Range(0f, 1f)] public float spawnChance = 1f;

    void Start()
    {
        // Check the random chance before spawning the clue
        if (Random.value <= spawnChance)
        {
            SpawnClue();
        }
    }

    void SpawnClue()
    {
        // Calculate a random height within the specified range
        float randomHeight = Random.Range(minHeight, maxHeight);

        // Calculate the spawn position
        Vector3 spawnPosition = new Vector3(transform.position.x + spawnDistance, randomHeight, 0f);

        // Instantiate the clue at the calculated position
        GameObject clue = Instantiate(cluePrefab, spawnPosition, Quaternion.identity);

        // Optionally, you can set the clue as a child of the spawner for organization
        clue.transform.parent = transform;
    }
}