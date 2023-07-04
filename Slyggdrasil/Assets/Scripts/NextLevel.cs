using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public NewCharacterController player1Controller; //Reference the character controller script for player 1
    public NewCharacterController player2Controller; //Reference the character controller script for player 2


    int levelNumber;



    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (player1Controller != null && player2Controller != null)
        { 
            if (player1Controller.GetPassed() == true && player2Controller.GetPassed() == true)
            {

                //Change to the next level
                SceneManager.LoadScene("Level3New");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the scene at the next index
                levelNumber = SceneManager.GetActiveScene().buildIndex + 2;
                Debug.Log("Level " + levelNumber + " loaded.");



            }
        }

        if ( player2Controller == null && player1Controller != null)
        {
            if (player1Controller.GetPassed() == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the scene at the next index
                levelNumber = SceneManager.GetActiveScene().buildIndex + 2;
                Debug.Log("Level " + levelNumber + " loaded.");
            }
        }

        if (player1Controller == null && player2Controller != null)
        {
            if (player2Controller.GetPassed() == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the scene at the next index
                levelNumber = SceneManager.GetActiveScene().buildIndex + 2;
                Debug.Log("Level " + levelNumber + " loaded.");
            }
        }

        if (player1Controller != null)
        {
            if (player1Controller.GetWin() == true)
            {
                SceneManager.LoadScene("Player1WinMenu"); //Load the winning screen for player 1

            }
        }
        if(player2Controller != null)
        {
            if (player2Controller.GetWin() == true)
            {
                SceneManager.LoadScene("Player2WinMenu"); //Load the winning screen for player 2

            }
        }
        

    }
    /*

    void FixedUpdate()
    {
        if (player1Object != null && player2Object != null)
        {
            if (player1Object.player1passed == true && player2Object.player2passed == true)
            {

                //Change to the next level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the scene at the next index
                levelNumber = SceneManager.GetActiveScene().buildIndex + 2;
                Debug.Log("Level " + levelNumber + " loaded.");



            }
        }

        if (player2Object == null && player1Object != null)
        {
            if (player1Object.player1passed == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the scene at the next index
                levelNumber = SceneManager.GetActiveScene().buildIndex + 2;
                Debug.Log("Level " + levelNumber + " loaded.");
            }
        }

        if (player1Object == null && player2Object != null)
        {
            if (player2Object.player2Object == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the scene at the next index
                levelNumber = SceneManager.GetActiveScene().buildIndex + 2;
                Debug.Log("Level " + levelNumber + " loaded.");
            }
        }

        if (player1Object != null)
        {
            if (player1Object.player1Win == true)
            {
                SceneManager.LoadScene("Player1WinMenu"); //Load the winning screen for player 1

            }
        }
        if (player2Object != null)
        {
            if (player2Object.player2Win == true)
            {
                SceneManager.LoadScene("Player2WinMenu"); //Load the winning screen for player 2

            }
        }


    }
    */
}
