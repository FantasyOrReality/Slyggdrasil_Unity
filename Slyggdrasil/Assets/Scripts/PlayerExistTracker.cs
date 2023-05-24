using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExistTracker : MonoBehaviour
{
    //Add variables we want to track
    public bool player1Alive = true;
    public bool player2Alive = true;


    void Start()
    {
       // MonitorLives();
    }

    void Update()
    {
        //MonitorLives(player1Alive, player2Alive);

    }

    public void MonitorLives(bool isPlayer1, bool isPlayer2, bool newPlayerAlive)
    {
        if (isPlayer1 == true && isPlayer2 == false)
        {
            player1Alive = newPlayerAlive;
        }
        else if(isPlayer1 == false && isPlayer2 == true)
        {
            player2Alive = newPlayerAlive;

        }

    }

    
}
