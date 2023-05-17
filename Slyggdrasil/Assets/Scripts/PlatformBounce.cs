//Script assisted by Brackeys on youtube
//https://www.youtube.com/watch?v=fHN-26GEVhA&t=197s
//Date started: 10/05/2023
//Date finished:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBounce : MonoBehaviour
{
    [SerializeField]
    public float jumpVelocity = 1000.0f;

	bool isGrounded;
	bool isMovingRight;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Identify the colliding object's rigidbody
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

    }

	public void Move(float move, bool jump, Rigidbody2D rb, Collision2D collision)
	{
		//only control the player if grounded or airControl is turned on
		if (isGrounded)
		{
			// Move the character by finding the target velocity
			//Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			//m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !isMovingRight)
			{
				//flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && isMovingRight)
			{
				//flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (isGrounded && jump && rb != null)
		{
			isGrounded = false;

			if (collision.gameObject.tag == "Platform")
			{
				Vector2 velocity = rb.velocity; //Get the vector
				velocity.y = jumpVelocity; //Modify a vector component
				rb.velocity = velocity; //Set back to vector
			}

		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		isMovingRight = !isMovingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	

}
