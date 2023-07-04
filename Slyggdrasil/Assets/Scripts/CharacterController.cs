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

	[Range(0, .3f)] [SerializeField] 
	private float m_MovementSmoothing = .05f; // How much to smooth out the movement

	//[SerializeField] 
	[SerializeField]
	public GameObject nextLevelDetector; //The detector for the next level

	/* Old lives system
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
	*/

	//Player lives system
	public int player1Lives;
	public int player2Lives;


	[SerializeField]
	public bool m_player1Alive = true; //Whether player 1 is dead or not
	[SerializeField]
	public bool m_player2Alive = true; //Whether player 2 is dead or not

	[SerializeField]
	public int levelBonus;


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
	public NextLevel nextLevel;
	//public PlayerExistTracker playerExistTracker;



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
				Destroy(player1Object);

			}

			if (!m_player2Alive)
			{
				Destroy(player2Object);
			}


			if (OnLandEvent == null) //If the land event hasn't been triggered
			{
				OnLandEvent = new UnityEvent(); //Trigger the landing event
			}
		}
	}

	private void FixedUpdate()
	{ 

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
    {/*
		//if (player1Object != null && player2Object == null)
		//{
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
					//player2passed = true;
					scoreCounter.UpdatePlayer1Score(levelBonus);
					//scoreCounter.UpdatePlayer2Score(0);
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
				else if (checkForDeath.player1Alive == false && checkForDeath.player2Alive == true)
				{
					Debug.Log("Collision between P2 and Trigger detected!");
					//player1passed = true;
					player2passed = true;
					scoreCounter.UpdatePlayer2Score(levelBonus);
					scoreCounter.UpdatePlayer1Score(0);
					StartCoroutine(Cooldown(10));
				}

			}
		
		}
		*/

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
				//Go through the new lives system
				//take away a life
				player1Lives = player1Lives - 1;

				//Check the lives to see if it's above 0
				if (player1Lives > 0)
				{

					//respawn if lives are above 0

				}
				else if (player1Lives<=0)
				{
					//checkForDeath.player1Alive = false;
					Destroy(player1Object, 0.0f);
					//m_player1Alive = false;
					Debug.Log("Player 1 lives = 0");

				}
				//Delete object if not



			}
			if (m_PlayerRigidBody.tag == "Player2")
			{
				
				//Check the lives to see if it's above 0
				if (player2Lives > 0)
				{
					player2Lives = player2Lives - 1;

					Debug.Log("Collision between P2 and death barrier detected!");

					//respawn if lives are above 0


				}
				else if (player2Lives<=0)
				{
					//checkForDeath.player2Alive = false;
					Destroy(player2Object, 0.0f);
					//m_player2Alive = false;
					Debug.Log("Player 2 lives = 0");

				}

			}
		//StartCoroutine(Cooldown(10));
		}
	}

	//public void Jump
    //{

    //}

	IEnumerator Cooldown(int cooldownTime)
    {
		yield return new WaitForSeconds(cooldownTime);
	}
}
