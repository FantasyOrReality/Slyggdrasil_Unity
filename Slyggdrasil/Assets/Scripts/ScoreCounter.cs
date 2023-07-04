using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    //Reference the controller
    public NewCharacterController playerController;

    //Get y values into integer variables
    private int player1Height;
    private int player2Height;

    private int player1Score;
    private int player2Score;

    [SerializeField]
    public int startingHeight = 0;

    //Get the end result of the score
    private int endScore1;
    private int endScore2;


    void Start()
    {
        if (playerController.GetPlayerID() == 1)
        {
            player1Height = playerController.GetTopHeight() + startingHeight * 10;

        }
        if (playerController.GetPlayerID() == 2)
        {
           player2Height = playerController.GetTopHeight() + startingHeight * 10;
        }
    }

    void FixedUpdate()
    {
        if (playerController.GetPlayerID() == 1)
        {
            if (playerController != null)
            {
                GetPlayer1Height();
                UpdatePlayer1Score(player1Height);
            }
        }

        if (playerController.GetPlayerID() == 2)
        {
            if (playerController != null)
            {
                GetPlayer2Height();
                UpdatePlayer2Score(player2Height);
            }
        }
    }

    public void GetPlayer1Height()
    {
        if(playerController.GetPlayerID() == 1)
        {
            player1Height = playerController.GetTopHeight() + startingHeight * 10;
            player1Height = player1Height / 10;
        }
    }

    public void GetPlayer2Height()
    {
        if (playerController.GetPlayerID() == 2)
        {
            player2Height = playerController.GetTopHeight() + startingHeight * 10;
            player2Height = player2Height / 10;

        }
    }

    //public setters
    public void UpdatePlayer1Score(int newPlayer1Height)
    {
        if (player1Height >= player1Score)
        {
            player1Score = newPlayer1Height ;
            newPlayer1Height = newPlayer1Height + startingHeight;
            endScore1 = player1Score + startingHeight;
            //Debug.Log(endScore1);

        }
    }

    public void UpdatePlayer2Score(int newPlayer2Height)
    {
        if (player2Height >= player2Score)
        {
            player2Score = newPlayer2Height;
            newPlayer2Height = newPlayer2Height + startingHeight;
            endScore2 = player2Score + startingHeight;

            //Debug.Log(endScore2);

        }
    }

    //Public getters
    public int GetP1EndScore()
    {
        return endScore1;
    }
    public int GetP2EndScore()
    {
        return endScore2;
    }



}
