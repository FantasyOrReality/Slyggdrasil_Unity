//Script assisted by Brackeys on youtube
//https://www.youtube.com/watch?v=dwcT-Dch0bA
//Date started: 20/04/2023
//Date finished: 10/05/2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller; //The character controller's variable
    public CharacterController controller; 

    public float moveSpeed = 40.0f; //The default moving speed

    float player1HorizontalMove = 0.0f; //The default move distance for player 1
    float player2HorizontalMove = 0.0f; //The default move distance for player 2
    //bool jump = true;

	[SerializeField] 
    private int playerNumber = 0; //The editor's variable for checking what player is using the script

    // Update is called once per frame
    void Update()
    {
        if(controller != null)
        {
            player1HorizontalMove = Input.GetAxisRaw("Player1Horizontal") * moveSpeed; //Get the input from player 1 and give it a move speed

        }

        if (controller != null)
        {
            player2HorizontalMove = Input.GetAxisRaw("Player2Horizontal") * moveSpeed; //Get the input from player 2 and give it a move speed
        }
    }

    void FixedUpdate()
    {
        if (controller != null)
        {
            //Move players
            if (playerNumber == 1)
            {
                controller.Move(player1HorizontalMove * Time.fixedDeltaTime);

            }
            else if (playerNumber == 2)
            {
                controller.Move(player2HorizontalMove * Time.fixedDeltaTime);
            }
            else
            {
                //Do nothing
            }
        }

    }
}
