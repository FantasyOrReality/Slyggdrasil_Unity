using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlatformInteractions : MonoBehaviour
{
    //Public data
    [SerializeField]
    private float jumpForce = 1500.0f;

    //Collision occurred
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Collided with rigidbody
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        //collision has a rigidbody?
        if (rb != null)
        {
            //Set up a velocity vector
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce; //Set the velocity to the pre-determined jumping height
            rb.velocity = velocity; //Set the collided object's velocity to our velocity variable
        }    
    }
}
