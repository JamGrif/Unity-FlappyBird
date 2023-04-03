using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    private float moveSpeed = 5;

    private float deadZone = -30;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x <= deadZone)
        {
            Debug.Log("Pipe Deleted!");
            Destroy(gameObject);
        }
    }
}
