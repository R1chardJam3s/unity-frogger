using System;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawnScript : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 5f;

    private float nextTimeToSpawn = 0f;

    private int[] lastSpawned = new int[2];

    public GameObject log;

    public Transform[] spawnPoints;

    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnLog();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnLog()
    {
        lastSpawned[1] = lastSpawned[0];
        int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        while(Array.Exists(lastSpawned, value => value.Equals(randomIndex))) {
            randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        }
        Transform spawnPoint = spawnPoints[randomIndex];
        lastSpawned[0] = randomIndex;
        Instantiate(log, spawnPoint.position, spawnPoint.rotation);
    }
}
