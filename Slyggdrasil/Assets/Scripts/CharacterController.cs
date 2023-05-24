//Original script: https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs
//Date started: 20/04/2023
//Date finished: 10/05/2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class CharacterController : MonoBehaviour
{
	//Editable variables
	[SerializeField]
	public GameObject player1Object;
	[SerializeField]
	public GameObject player2Object;

	[SerializeField]
	public float m_JumpVelocity = 800.0f;

	[Range(0, .3f)] [SerializeField] 
	private float m_MovementSmoothing = .05f; // How much to smooth out the movement

	//[SerializeField] 
	//private bool m_AirControl = true; // Whether or not a player can steer while jumping;
	[SerializeField] 
	private LayerMask m_WhatIsGround; // A mask determining what is ground to the character
	[SerializeField]
	private LayerMask m_WhatIsFakeGround; // A mask determining what is fake to the character
	[SerializeField] 
	private Transform m_GroundCheck; // A position marking where to check if the player is grounded.
	[SerializeField] 
	private Transform m_CeilingCheck; // A position marking where to check for ceilings
	[SerializeField]
	public GameObject nextLevelDetector; //The detector for the next level

	[SerializeField]
	public bool m_player1Life = true; //The default life player 1 starts with
	[SerializeField]
	public bool m_player1BonusLife = false; //Bonus life player 1 is granted by the first revival upgrade
	[SerializeField]
	public bool m_player1BonusLife2 = false; //A second bonus life player 1 is granted by another revival upgrade

	[SerializeField]
	public bool m_player2Life = true; //The default life player 2 starts with
	[SerializeField]
	public bool m_player2BonusLife = false; //Bonus life player 2 is granted by the first revival upgrade
	[SerializeField]
	public bool m_player2BonusLife2 = false; //A second bonus life player 2 is granted by another revival upgrade
	[SerializeField]
	public bool m_player1Alive = true; //Whether player 1 is dead or not
	[SerializeField]
	public bool m_player2Alive = true; //Whether player 2 is dead or not

	[SerializeField]
	public int levelBonus;


	//Constants
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private bool m_Grounded;            // Whether or not the player is grounded.

	//Un-editable variables
	public Rigidbody2D m_PlayerRigidBody; //The player's rigidbody2D
	private bool m_MovingRight = true;  // For determining which way the player is currently moving.
	private Vector3 m_Velocity = Vector3.zero; //The velocity of the player

	public bool player1passed = false;
	public bool player2passed = false;

	public bool player1Win = false;
	public bool player2Win = false;

	//References
	[SerializeField]
	public CheckDeath checkForDeath;

	public StatManager statManager;
	public ScoreCounter scoreCounter;



	[Header("Events")]
	[Space]

	private UnityEvent OnLandEvent; //When the player lands

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { } //The event class is declared

	private void Awake()
	{
		if (player1Object != null && player2Object != null)
		{
			m_PlayerRigidBody = GetComponent<Rigidbody2D>(); //The player's rigid body being assigned
		
			if (!m_player1Alive)
			{
				Destroy(player1Object, 0.1f);

			}

			if (!m_player2Alive)
			{
				Destroy(player2Object, 0.1f);
			}


			if (OnLandEvent == null) //If the land event hasn't been triggered
			{
				OnLandEvent = new UnityEvent(); //Trigger the landing event
			}
		}
	}

	private void FixedUpdate()
	{
		if (player1Object != null)
		{
			bool wasGrounded = m_Grounded; //Assigning the last recorded player landing
			m_Grounded = false; //Reset the grounded state

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround); //Create the collider array for checking the platform collisions
			Collider2D[] fakeColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsFakeGround); //Create the collider array for checking the fake platform collisions

			for (int i = 0; i < colliders.Length; i++) //For each collider in the array...
			{
				if (colliders[i].gameObject != gameObject)
				{
					// Add a vertical force to the player
					Vector2 velocity = m_PlayerRigidBody.velocity; //Get the vector
					velocity.y = m_JumpVelocity; //Modify a vector component
					m_PlayerRigidBody.velocity = velocity; //Set back to vector

					m_Grounded = true; //Set the grounded state





					//if (!wasGrounded)
					//{
					//OnLandEvent.Invoke();//Start the Landing event
					//}
				}
			}

			for (int i = 0; i < fakeColliders.Length; i++) //For each collider in the array...
			{
				if (fakeColliders[i].gameObject != gameObject)
				{
					m_Grounded = true; //Set the grounded state


					// Let the player fall
					//Debug.Log("FakePlatform Collision");



					//OnLandEvent.Invoke();//Start the Landing event

				}
			}
		}

		if (player2Object != null)
		{
			bool wasGrounded = m_Grounded; //Assigning the last recorded player landing
			m_Grounded = false; //Reset the grounded state

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround); //Create the collider array for checking the platform collisions
			Collider2D[] fakeColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsFakeGround); //Create the collider array for checking the fake platform collisions

			for (int i = 0; i < colliders.Length; i++) //For each collider in the array...
			{
				if (colliders[i].gameObject != gameObject)
				{
					// Add a vertical force to the player
					Vector2 velocity = m_PlayerRigidBody.velocity; //Get the vector
					velocity.y = m_JumpVelocity; //Modify a vector component
					m_PlayerRigidBody.velocity = velocity; //Set back to vector

					m_Grounded = true; //Set the grounded state





					//if (!wasGrounded)
					//{
					//OnLandEvent.Invoke();//Start the Landing event
					//}
				}
			}

			for (int i = 0; i < fakeColliders.Length; i++) //For each collider in the array...
			{
				if (fakeColliders[i].gameObject != gameObject)
				{
					m_Grounded = true; //Set the grounded state


					// Let the player fall
					//Debug.Log("FakePlatform Collision");



					//OnLandEvent.Invoke();//Start the Landing event

				}
			}
		}
		}


	public void Move(float move)
	{
		if (player1Object != null)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_PlayerRigidBody.velocity.y);
			// And then smoothing it out and applying it to the character
			m_PlayerRigidBody.velocity = Vector3.SmoothDamp(m_PlayerRigidBody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);


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

			// If the player should jump...
			//if (m_Grounded && jump)
			//{
			//m_Grounded = false;

			// Add a vertical force to the player
			//m_PlayerRigidBody.AddForce(new Vector2(0f, m_JumpVelocity));

			//}
		}

		if (player2Object != null)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_PlayerRigidBody.velocity.y);
			// And then smoothing it out and applying it to the character
			m_PlayerRigidBody.velocity = Vector3.SmoothDamp(m_PlayerRigidBody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);


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

			// If the player should jump...
			//if (m_Grounded && jump)
			//{
			//m_Grounded = false;

			// Add a vertical force to the player
			//m_PlayerRigidBody.AddForce(new Vector2(0f, m_JumpVelocity));

			//}
		}
	}


	private void Flip()
	{
		if (player1Object != null && player2Object != null)
		{
			// Switch the way the player is labelled as facing.
			m_MovingRight = !m_MovingRight;

			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
		if (player1Object != null && player2Object != null)
		{
			if (collision.tag == "CounterTrigger")
			{
				if (m_PlayerRigidBody.tag == "Player1")
				{
					if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == true)
					{
						Debug.Log("Collision between P1 and Trigger detected!");
						player1passed = true;
						scoreCounter.UpdatePlayer1Score(levelBonus);
						StartCoroutine(Cooldown(10));
					}

					else if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == false)
					{
						Debug.Log("Collision between P1 and Trigger detected!");
						player1passed = true;
						player2passed = true;
						scoreCounter.UpdatePlayer1Score(levelBonus);
						scoreCounter.UpdatePlayer2Score(0);
						StartCoroutine(Cooldown(10));
					}

				}
				if (m_PlayerRigidBody.tag == "Player2")
				{
					if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == true)
					{
						Debug.Log("Collision between P2 and Trigger detected!");
						player2passed = true;

						scoreCounter.UpdatePlayer2Score(levelBonus);

						StartCoroutine(Cooldown(10));
					}
					else if (checkForDeath.player1Alive == false && checkForDeath.player2Alive == false)
					{
						Debug.Log("Collision between P2 and Trigger detected!");
						player1passed = true;
						player2passed = true;
						scoreCounter.UpdatePlayer2Score(levelBonus);
						scoreCounter.UpdatePlayer1Score(0);
						StartCoroutine(Cooldown(10));
					}

				}
			}

			if (collision.tag == "WinTrigger")
			{
				if (m_PlayerRigidBody.tag == "Player1")
				{
					player1Win = true;
					player2Win = false;
				}
				else if (m_PlayerRigidBody.tag == "Player2")
				{
					player1Win = false;
					player2Win = true;
				}

			}

			if (collision.tag == "DeathTrigger")
			{
				if (m_PlayerRigidBody.tag == "Player1")
				{
					Debug.Log("Collision between P1 and death barrier detected!");

					//Go through the life system
					if (m_player1BonusLife2 == true)
					{
						StartCoroutine(Cooldown(10));
						Debug.Log("Player 1 lives = 2");
						m_player1BonusLife2 = false;


					}
					else if (m_player1BonusLife2 == false && m_player1BonusLife == true)
					{
						StartCoroutine(Cooldown(10));
						Debug.Log("Player 1 lives = 1");
						m_player1BonusLife = false;



					}
					else if (m_player1BonusLife2 == false && m_player1BonusLife == false && m_player1Life == true)
					{
						m_player1Life = false;
						m_player1Alive = false;
						checkForDeath.player1Alive = false;
						Destroy(player1Object, 0.1f);
						Debug.Log("Player 1 lives = 0");


					}




				}
				else if (m_PlayerRigidBody.tag == "Player2")
				{
					Debug.Log("Collision between P2 and death barrier detected!");
					//Go through the life system
					if (m_player2BonusLife2 == true)
					{
						m_player2BonusLife2 = false;
						StartCoroutine(Cooldown(10));
						Debug.Log("Player 2 lives = 2");

					}
					else if (m_player2BonusLife == true)
					{
						m_player2BonusLife = false;
						StartCoroutine(Cooldown(10));
						Debug.Log("Player 2 lives = 1");


					}
					else if (m_player2Life == true)
					{
						m_player2Life = false;
						m_player2Alive = false;
						checkForDeath.player2Alive = false;


						Destroy(player2Object, 0.1f);

						Debug.Log("Player 2 lives = 0");



					}

				}

			}


			StartCoroutine(Cooldown(10));
		}
	}

	IEnumerator Cooldown(int cooldownTime)
    {
		yield return new WaitForSeconds(cooldownTime);
	}
}
