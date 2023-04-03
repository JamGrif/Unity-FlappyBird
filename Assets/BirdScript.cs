using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    private float flapStrength = 15.0f;
    private LogicScript logic;

    private bool birdIsAlive = true;

    private float maximumZRotation = 15.0f;
    private float minimumZRotation = -35.0f;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;

            // Reset Z rotation
            Vector3 temp = transform.rotation.eulerAngles;
            temp.z = 0.0f;
            transform.rotation = Quaternion.Euler(temp);

        }

        if (myRigidbody.velocity.y < 0)
        {
            // Bird moving down
            var target = Quaternion.Euler(0, 0, minimumZRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
        }
        else if (myRigidbody.velocity.y > 0)
        {
            // Bird moving up
            var target = Quaternion.Euler(0, 0, maximumZRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10.0f);
        }
    }

    private void KillBird()
    {
        if (!birdIsAlive)
            return;

        Debug.Log("bird has dead");

        logic.gameOver();
        birdIsAlive = false;

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        // remove rotation velocity
        myRigidbody.angularVelocity = 0.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        KillBird();
    }
}
