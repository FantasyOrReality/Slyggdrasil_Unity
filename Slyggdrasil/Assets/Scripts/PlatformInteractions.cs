using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteractions : MonoBehaviour
{
    //Different Jump values for different jump types
    [SerializeField]
    private float baseJumpForce = 1500.0f;
    [SerializeField]
    private float iceJumpForce = 2000.0f;
    [SerializeField]
    private float fakeJumpForce = 0.0f;
    [SerializeField]
    private float movingJumpForce = 1500.0f;

    //Collision occurred
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Collided with rigidbody
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        //collision has a rigidbody?
        if (rb != null)
        {
            //Base platforms
            if (this.CompareTag("Base"))
            {
                Vector2 velocityBase = rb.velocity;
                velocityBase.y = baseJumpForce; //Set the velocity to the pre-determined jumping height
                rb.velocity = velocityBase; //Set the collided object's velocity to our velocity variable
            }
            //Ice platforms
            if (this.CompareTag("Ice"))
            {
                Vector2 velocityIce = rb.velocity;
                velocityIce.y = iceJumpForce; //Set the velocity to the pre-determined jumping height
                rb.velocity = velocityIce; //Set the collided object's velocity to our velocity variable
            }    
            //Fake platforms
            if (this.CompareTag("Fake"))
            {
                Vector2 velocityFake = rb.velocity;
                velocityFake.y = fakeJumpForce; //Set the velocity to the pre-determined jumping height
                rb.velocity = velocityFake; //Set the collided object's velocity to our velocity variable
            }
            //Moving platforms
            if (this.CompareTag("Moving"))
            {
                Vector2 velocityMoving = rb.velocity;
                velocityMoving.y = movingJumpForce; //Set the velocity to the pre-determined jumping height
                rb.velocity = velocityMoving; //Set the collided object's velocity to our velocity variable
            }

        }    
    }
}
