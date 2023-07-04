using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class NewCharacterController : MonoBehaviour
{
    //Object components
    [SerializeField]
    SpriteRenderer playerSprite;
    [SerializeField]
    CapsuleCollider2D playerCollider2D;

    [SerializeField]
    private int playerID = 0;
    private int playerHeight = 0;
    private int playerTopHeight = 0;
	[SerializeField]
	private int levelBonus;
    private int numberOfPlayerDeaths = 0;

	private float movementSpeed = 1000.0f;

    [SerializeField]
    private bool playerAlive = true;

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
    public void SetAlive(bool aliveSetter)
    {
        playerAlive = aliveSetter;
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
    public bool GetAlive()
    {
        return playerAlive;
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
    public int GetNumberOfPlayerDeaths()
    {
        return numberOfPlayerDeaths;
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

    //Private collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.transform.tag == "CounterTrigger")
		{
			if (playerID == 1)
			{
                //Debug.Log("Collision between P1 and Trigger detected!");

                if (checkForDeath.GetCheckAlive1() == true && checkForDeath.GetCheckAlive2() == true)
				{
					SetPassed(true);
					scoreCounter.UpdatePlayer1Score(levelBonus);
				}

				else if (checkForDeath.GetCheckAlive1() == true && checkForDeath.GetCheckAlive2() == false)
				{
					SetPassed(true);
					scoreCounter.UpdatePlayer1Score(levelBonus);
				}

			}
			if (playerID ==2)
			{
                //Debug.Log("Collision between P2 and Trigger detected!");

                if (checkForDeath.GetCheckAlive1() == true && checkForDeath.GetCheckAlive2() == true)
				{
					SetPassed(true);

					scoreCounter.UpdatePlayer2Score(levelBonus);

				}
				else if (checkForDeath.GetCheckAlive1() == false && checkForDeath.GetCheckAlive2() == true)
				{
					SetPassed(true);

					scoreCounter.UpdatePlayer2Score(levelBonus);
				}

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

		if (collision.transform.tag == "DeathTrigger")
        {
			if (playerID == 1)
            {
                SetAlive(false);
                Destroy(playerSprite);
                Destroy(playerCollider2D);
                numberOfPlayerDeaths += 1;
            }
            if (playerID == 2)
            {
                SetAlive(false);
                //SetPassed(true);
                Destroy(playerSprite);
                Destroy(playerCollider2D);
                numberOfPlayerDeaths += 1;


            }
        }
	}
	
}
