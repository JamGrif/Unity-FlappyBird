using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    private CloudSpawnerScript cloudSpawner;

    public float moveSpeed = 0;

    private float minimumSpeed = 3;
    private float maximumSpeed = 7;

    private float minimumOpacity = 0.1f;
    private float maximumOpacity = 0.5f;

    public float deadZone = -30;

    void Start()
    {
        moveSpeed = Random.Range(minimumSpeed, maximumSpeed);

        float spriteOpacity = Random.Range(minimumOpacity, maximumOpacity);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, spriteOpacity);

        cloudSpawner = GameObject.FindGameObjectWithTag("CloudSpawner").GetComponent<CloudSpawnerScript>();
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x <= deadZone)
        {
            Debug.Log("Cloud Deleted!");
            Destroy(gameObject);
            cloudSpawner.CloudHasDied();
        }
    }
}
