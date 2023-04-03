using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrollingScript : MonoBehaviour
{
    //public GameObject ParallaxImage1;
    //public GameObject ParallaxImage2;

    // If the sprite reaches this X Position, then reset its X position
    private float DeadZoneX = -47.0f;

    private float ResetXPos = 47.04f;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x <= -47.0)
        {
            transform.position = new Vector3(ResetXPos, -2.5f, 0);
        }

        //if (ParallaxImage2.transform.position.x <= -47.0)
        //{
        //    ParallaxImage2.transform.position = new Vector3(ResetXPos, -2.5f, 0);
        //}

        transform.position = transform.position + (Vector3.left * 2) * Time.deltaTime;
        //ParallaxImage2.transform.position = ParallaxImage2.transform.position + (Vector3.left * 2) * Time.deltaTime;
    }
}
