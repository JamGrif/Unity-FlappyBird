using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject cloud;

    private int CurrentClouds = 0;
    private const int MaxClouds = 5;

    // New cloud will be spawned between this range
    private float minSpawnWait = 1.0f;
    private float maxSpawnWait = 3.0f;

    // Time until next cloud is spawned
    private float currentSpawnWait = 0.0f;

    private float timer = 0.0f;

    void Start()
    {
        currentSpawnWait = Random.Range(minSpawnWait, maxSpawnWait);


    }

    void Update()
    {
        // No more room for clouds
        if (CurrentClouds == MaxClouds)
            return;

        if (timer > currentSpawnWait)
        {
            SpawnCloud();
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
        }



    }

    void SpawnCloud()
    {
        CurrentClouds++;
        Instantiate(cloud, new Vector3(transform.position.x, 0, 0), transform.rotation);
    }

}
