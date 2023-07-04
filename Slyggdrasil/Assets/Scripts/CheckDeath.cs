using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckDeath : MonoBehaviour
{
    public NewCharacterController player1Controller; //Reference the character controller script for player 1
    public NewCharacterController player2Controller; //Reference the character controller script for player 2

    public bool player1Alive;
    public bool player2Alive;

    //public int player1Lives;
    //public int player2Lives;

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (player1Controller != null && player2Controller != null)
        //{


            //if (player1Alive == false)
            //{
            //Debug.Log("Player 1 is dead");
            //Destroy the game object for player 1 
            //StartCoroutine(Cooldown(10));

            //}
            //else if (player2Alive == false)
            //{
            //Debug.Log("Player 2 is dead");

            //Destroy the game object for player 2 

            //StartCoroutine(Cooldown(10));


            //}
        if (player1Controller != null)
        {
            if (player1Alive == false)
            {
                //Destroy(player1Controller.gameObject);
            }
        }
        
        if (player2Controller != null)
        {
            if (player2Alive == false)
            {
                //Destroy(player2Controller.gameObject);
            }
        }

        

        if (player1Alive == false && player2Alive == false)
        {
            //Change to the loss screen
            SceneManager.LoadScene("LossMenu"); //Load the lose screen 

        }
        //}
    }

    IEnumerator Cooldown(int cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
    }


}
