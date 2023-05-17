using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public CharacterController player1Controller; //Reference the character controller script for player 1
    public CharacterController player2Controller; //Reference the character controller script for player 2

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (player1Controller.player1passed == true && player2Controller.player2passed == true)
        {
            //Change to the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the scene at the next index
            Debug.Log("Level " + SceneManager.GetActiveScene().buildIndex+1 + " loaded.");

        }

    }
}
