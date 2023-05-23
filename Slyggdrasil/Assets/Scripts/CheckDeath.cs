using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckDeath : MonoBehaviour
{
    public CharacterController player1Controller; //Reference the character controller script for player 1
    public CharacterController player2Controller; //Reference the character controller script for player 2


    // Update is called once per frame
    void FixedUpdate()
    {

        if (player1Controller.m_player1Alive == false)
        {
            Debug.Log("Player 1 is dead");
            //Destroy the game object for player 1 
            StartCoroutine(Cooldown(10));

        }
        else if (player2Controller.m_player2Alive == false)
        {
            Debug.Log("Player 2 is dead");

            //Destroy the game object for player 2 

            StartCoroutine(Cooldown(10));


        }

        else if (player1Controller.m_player1Alive == false && player2Controller.m_player2Alive == false)
        {

            //Change to the loss screen
            SceneManager.LoadScene("LossMenu"); //Load the lose screen 

        }

    }

    IEnumerator Cooldown(int cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
    }
}
