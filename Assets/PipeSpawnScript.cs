using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;

    // How many seconds before spawns
    private float spawnRate = 3.5f;

    // The number that counts up
    private float timer = 0;

    private float heightOffset = 10;

    // The centre of the pipe will be between these values
    private float lowestYPos = -7.0f;
    private float highestYPos = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }

    }

    void spawnPipe()
    {

        Instantiate(pipe, new Vector3(30, Random.Range(lowestYPos, highestYPos), transform.position.z), transform.rotation);
    }

}
