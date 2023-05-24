using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    //Reference the controller
    public CharacterController player1Controller;
    public CharacterController player2Controller;

    //Get y values into integer variables
    public int player1Height;
    public int player2Height;

    public int player1Score;
    public int player2Score;

    [SerializeField]
    public int startingHeight = 0;
    


    void Start()
    {
        player1Height = (int)player1Controller.m_PlayerRigidBody.position.y + startingHeight*10;
        player2Height = (int)player2Controller.m_PlayerRigidBody.position.y + startingHeight * 10;
    }

    void FixedUpdate()
    {
        GetPlayer1Height();
        UpdatePlayer1Score(player1Height);


        GetPlayer2Height();
        UpdatePlayer2Score(player2Height);

    }

    public void GetPlayer1Height()
    {
        if(player1Controller.player1Object.tag == "Player1")
        {
            player1Height = (int)player1Controller.m_PlayerRigidBody.position.y + startingHeight*10;
            player1Height = player1Height / 10;
        }
        else
        {

        }

        
    }

    public void GetPlayer2Height()
    {
        if (player2Controller.player2Object.tag == "Player2")
        {
            player2Height = (int)player2Controller.m_PlayerRigidBody.position.y + startingHeight * 10;
            player2Height = player2Height / 10;

        }
        else
        {

        }
    }


    public void UpdatePlayer1Score(int newPlayer1Height)
    {
        if (player1Height >= player1Score)
        {
            player1Score = newPlayer1Height ;
            newPlayer1Height = newPlayer1Height + startingHeight;

            Debug.Log(player1Score + startingHeight);

        }
    }

    public void UpdatePlayer2Score(int newPlayer2Height)
    {
        if (player2Height >= player2Score)
        {
            player2Score = newPlayer2Height;
            newPlayer2Height = newPlayer2Height + startingHeight;

            Debug.Log(player2Score + startingHeight);

        }
    }
    


}
