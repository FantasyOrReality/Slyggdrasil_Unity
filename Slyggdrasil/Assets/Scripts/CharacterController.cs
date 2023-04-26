//Original script: https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs
//Date started: 20/04/2023
//Date finished: 26/04/2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
	[SerializeField] //This makes private variables into editable variables in unity
	private float m_JumpForce = 400f; // Amount of force added when the player jumps.

	[Range(0, .3f)] [SerializeField] 
	private float m_MovementSmoothing = .05f; // How much to smooth out the movement

	[SerializeField] 
	private bool m_AirControl = true; // Whether or not a player can steer while jumping;
	[SerializeField] 
	private LayerMask m_WhatIsGround; // A mask determining what is ground to the character
	[SerializeField] 
	private Transform m_GroundCheck; // A position marking where to check if the player is grounded.
	[SerializeField] 
	private Transform m_CeilingCheck; // A position marking where to check for ceilings

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D; //The player's rigidbody2D
	private bool m_MovingRight = true;  // For determining which way the player is currently moving.
	private Vector3 m_Velocity = Vector3.zero; //The velocity of the player

	[Header("Events")]
	[Space]

	private UnityEvent OnLandEvent; //When the player lands

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { } //The event class is declared

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>(); //The player's rigid body being assigned

		if (OnLandEvent == null) //If the land event hasn't been triggered
		{
			OnLandEvent = new UnityEvent(); //Trigger the landing event
		}
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded; //Assigning the last recorded player landing
		m_Grounded = false; //Reset the grounded state

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround); //Create the collider array for checking the ground and roof collisions
		for (int i = 0; i < colliders.Length; i++) //For each collider in the array...
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true; //Set the grounded state
				

				// Add a vertical force to the player
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
				if (!wasGrounded)
				{
					OnLandEvent.Invoke();//Start the Landing event
				}
			}
		}
	}


	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);


			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_MovingRight)
			{
				//flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_MovingRight)
			{
				//flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			m_Grounded = false;

			// Add a vertical force to the player
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_MovingRight = !m_MovingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
