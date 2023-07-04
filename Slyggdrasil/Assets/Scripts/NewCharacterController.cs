using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class NewCharacterController : MonoBehaviour
{
    [SerializeField]
    private int playerID = 0;
    private int playerHeight = 0;
    private int playerTopHeight = 0;
	[SerializeField]
	private int levelBonus;

	private float movementSpeed = 1000.0f;

	[SerializeField]
	private bool playerPassed = false;
    private bool playerWin = false;

    Rigidbody2D rb;
    private float movement = 0.0f;

	
	//References
	[SerializeField]
	public CheckDeath checkForDeath;

	public StatManager statManager;
	public ScoreCounter scoreCounter;
	public NextLevel nextLevel;

	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetTopHeight(playerHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerID != 0)
        {
            if (playerID == 1)
            {
                movement = Input.GetAxis("Player1Horizontal")*movementSpeed;
                
            }
            else if (playerID == 2)
            {
                movement = Input.GetAxis("Player2Horizontal")*movementSpeed;

            }
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

        SetHeight((int)rb.transform.position.y);

        if (GetHeight()>= GetTopHeight())
        {
            SetTopHeight(GetHeight());
        }

    }

    //Public Setters
    public void SetPassed(bool passedSetter)
    {
        playerPassed = passedSetter;
    }
    public void SetWin(bool winSetter)
    {
        playerWin = winSetter;
    }

    //Public Getters
    public bool GetPassed()
    {
        return playerPassed;
    }
    public bool GetWin()
    {
        return playerWin;
    }
    
    public int GetPlayerID()
    {
        return playerID;
    }
    public int GetHeight()
    {
        return playerHeight;
    }
    public int GetTopHeight()
    {
        return playerTopHeight;
    }

    //Private setters
    private void SetHeight(int newHeight)
    {
        playerHeight = newHeight;
    }
    private void SetTopHeight(int newTopHeight)
    {
        playerTopHeight = newTopHeight;
    }

    //Private getters

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.transform.tag == "CounterTrigger")
		{
			if (playerID == 1)
			{
				//if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == true)
				//{
					Debug.Log("Collision between P1 and Trigger detected!");
					SetPassed(true);
					scoreCounter.UpdatePlayer1Score(levelBonus);
					//StartCoroutine(Cooldown(10));
				//}

				//else if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == false)
				//{
					Debug.Log("Collision between P1 and Trigger detected!");
					SetPassed(true);
					//player2passed = true;
					scoreCounter.UpdatePlayer1Score(levelBonus);
					//scoreCounter.UpdatePlayer2Score(0);
					//StartCoroutine(Cooldown(10));
				//}

			}
			if (playerID ==2)
			{
				//if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == true)
				//{
					Debug.Log("Collision between P2 and Trigger detected!");
					SetPassed(true);

					scoreCounter.UpdatePlayer2Score(levelBonus);

					//StartCoroutine(Cooldown(10));
				//}
				//else if (checkForDeath.player1Alive == false && checkForDeath.player2Alive == true)
				//{
					Debug.Log("Collision between P2 and Trigger detected!");
					//player1passed = true;
					SetPassed(true);
					scoreCounter.UpdatePlayer2Score(levelBonus);
					scoreCounter.UpdatePlayer1Score(0);
					//StartCoroutine(Cooldown(10));
				//}

			}
		}

		if (collision.transform.tag == "WinTrigger")
		{
			if (playerID == 1)
			{
				if (playerID == 1)
				{
					playerWin = true;
				}
				else if (playerID == 2)
				{
					playerWin = false;
				}
			}
			else if (playerID == 2)
			{
				if (playerID == 1)
				{
					playerWin = false;
				}
				else if (playerID == 2)
				{
					playerWin = true;
				}
			}

		}
	}
	/*
    void OnTriggerEnter2D(Collider2D collision)
	{
		//if (player1Object != null && player2Object == null)
		//{
		if (collision.tag == "CounterTrigger")
		{
			if (rb.tag == "Player1")
			{
				if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == true)
				{
					Debug.Log("Collision between P1 and Trigger detected!");
					playerPassed = true;
					scoreCounter.UpdatePlayer1Score(levelBonus);
					//StartCoroutine(Cooldown(10));
				}

				else if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == false)
				{
					Debug.Log("Collision between P1 and Trigger detected!");
					playerPassed = true;
					//player2passed = true;
					scoreCounter.UpdatePlayer1Score(levelBonus);
					//scoreCounter.UpdatePlayer2Score(0);
					//StartCoroutine(Cooldown(10));
				}

			}
			if (rb.tag == "Player2")
			{
				if (checkForDeath.player1Alive == true && checkForDeath.player2Alive == true)
				{
					Debug.Log("Collision between P2 and Trigger detected!");
					playerPassed = true;

					scoreCounter.UpdatePlayer2Score(levelBonus);

					//StartCoroutine(Cooldown(10));
				}
				else if (checkForDeath.player1Alive == false && checkForDeath.player2Alive == true)
				{
					Debug.Log("Collision between P2 and Trigger detected!");
					//player1passed = true;
					playerPassed = true;
					scoreCounter.UpdatePlayer2Score(levelBonus);
					scoreCounter.UpdatePlayer1Score(0);
					//StartCoroutine(Cooldown(10));
				}

			}
		}

		if (collision.tag == "WinTrigger")
		{
			if (rb.tag == "Player1")
			{
				if (playerID == 1)
				{
					playerWin = true;
				}
				else if (playerID == 2)
				{
					playerWin = false;
				}
			}
			else if (rb.tag == "Player2")
			{
				if (playerID == 1)
				{
					playerWin = false;
				}
				else if (playerID == 2)
				{
					playerWin = true;
				}
			}

		}

		if (collision.tag == "DeathTrigger")
		{
			if (rb.tag == "Player1")
			{
				Debug.Log("Collision between P1 and death barrier detected!");
				//Go through the new lives system
				//take away a life
				//player1Lives = player1Lives - 1;

				//Check the lives to see if it's above 0
				/*
				if (player1Lives > 0)
				{

					//respawn if lives are above 0

				}
				else if (player1Lives <= 0)
				{
					checkForDeath.player1Alive = false;
					Destroy(player1Object, 0.0f);
					//m_player1Alive = false;
					Debug.Log("Player 1 lives = 0");

				}
				
				//Delete object if not



			}
			if (rb.tag == "Player2")
			{

				//Check the lives to see if it's above 0
				/*
				if (player2Lives > 0)
				{
					player2Lives = player2Lives - 1;

					Debug.Log("Collision between P2 and death barrier detected!");

					//respawn if lives are above 0


				}
				else if (player2Lives <= 0)
				{
					checkForDeath.player2Alive = false;
					Destroy(player2Object, 0.0f);
					//m_player2Alive = false;
					Debug.Log("Player 2 lives = 0");

				}
				
			}
			//StartCoroutine(Cooldown(10));
		}
			
	}
			*/
}
