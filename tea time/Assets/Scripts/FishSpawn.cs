using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject[] fishPrefabs;
    public float spawnInterval = 2f;
    public Vector3 spawnPosition = new Vector3(-10, 0, 0);
    public Vector3 spawnOffsetRange = new Vector3(0, 3, 3);

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnFish();
            timer = 0f;
        }
    }

    void SpawnFish()
    {
        if (fishPrefabs.Length == 0) return;

        int index = Random.Range(0, fishPrefabs.Length);
        GameObject chosenFish = fishPrefabs[index];

        Vector3 randomOffset = new Vector3(
            0,
            Random.Range(-spawnOffsetRange.y, spawnOffsetRange.y),
            Random.Range(-spawnOffsetRange.z, spawnOffsetRange.z)
        );

        Instantiate(chosenFish, spawnPosition + randomOffset, Quaternion.identity);
    }
}
