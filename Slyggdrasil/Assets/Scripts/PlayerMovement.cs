//Script assisted by Brackeys on youtube
//https://www.youtube.com/watch?v=dwcT-Dch0bA
//Date started: 20/04/2023
//Date finished: ??/??/2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 40.0f;

    float player1HorizontalMove = 0.0f;
    float player2HorizontalMove = 0.0f;

	[SerializeField] 
    private int playerNumber=0;

    // Update is called once per frame
    void Update()
    {
        player1HorizontalMove = Input.GetAxisRaw("Player1Horizontal") * moveSpeed;
        player2HorizontalMove = Input.GetAxisRaw("Player2Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        //Move player
        if (playerNumber == 1)
        {
            controller.Move(player1HorizontalMove * Time.fixedDeltaTime, false);

        }
        else if (playerNumber == 2)
        {
            controller.Move(player2HorizontalMove * Time.fixedDeltaTime, false);
        }
        else
        {

        }    

    }
}
