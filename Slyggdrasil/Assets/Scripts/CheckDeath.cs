using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckDeath : MonoBehaviour
{
    public NewCharacterController player1Controller; //Reference the character controller script for player 1
    public NewCharacterController player2Controller; //Reference the character controller script for player 2

    private bool player1Alive = true;

    private bool player2Alive =true;
    

    //public int player1Lives;
    //public int player2Lives;

    void FixedUpdate()
    {
        if (player1Controller != null && player2Controller != null)
        {


            if (player1Controller.GetAlive() == false)
            {
                //Debug.Log("Player 1 is dead");

                SetCheckAlive1(false);
            }
            else if (player2Controller.GetAlive() == false)
            {
                //Debug.Log("Player 2 is dead");

                SetCheckAlive2(false);
            }

            if (player1Controller.GetAlive() == false && player2Controller.GetAlive() == false)
            {
                //Change to the loss screen
                SceneManager.LoadScene("LossMenu"); //Load the lose screen 

            }
        }
    }

    //Public getters
    public bool GetCheckAlive1()
    {
        return player1Alive;
    }
    public bool GetCheckAlive2()
    {
        return player2Alive;
    }

    //Public setters
    public void SetCheckAlive1(bool checkAliveSetter1)
    {
        player1Alive = checkAliveSetter1;
    }
    public void SetCheckAlive2(bool checkAliveSetter2)
    {
        player2Alive = checkAliveSetter2;

    }

    IEnumerator Cooldown(int cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
    }


}
