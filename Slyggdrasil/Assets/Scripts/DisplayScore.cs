using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    //Reference the scores
    public ScoreCounter player1Score;
    public ScoreCounter player2Score;

    //Add text
    public Text scoreText;

    void Update()
    {
        scoreText.text = player1Score.endScore1.ToString();
    }
}
