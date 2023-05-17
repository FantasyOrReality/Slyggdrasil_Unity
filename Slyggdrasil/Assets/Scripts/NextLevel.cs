using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("this is where the next level would start");
        }

    }
}
