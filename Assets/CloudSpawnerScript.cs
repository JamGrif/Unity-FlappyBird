using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject cloud;

    private int CurrentClouds = 0;
    private const int MaxClouds = 15;

    // New cloud will be spawned between this range
    private float minSpawnWait = 2.0f;
    private float maxSpawnWait = 4.0f;

    // Time until next cloud is spawned
    private float currentSpawnWait = 0.0f;

    private float timer = 0.0f;

    private float lowestPoint = -4.0f;
    private float highestPoint = 13.0f;

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

        float yPos = Random.Range(lowestPoint, highestPoint);

        Instantiate(cloud, new Vector3(transform.position.x, yPos, 0), transform.rotation);
    }

    public void CloudHasDied()
    {
        CurrentClouds--;
    }

}
