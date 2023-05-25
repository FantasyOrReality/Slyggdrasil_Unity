using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    //Reference the scores
    public ScoreCounter player1Score;
    public ScoreCounter player2Score;

    //Add text
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;


    void Update()
    {
        player1ScoreText.text = "HGT : " + player1Score.endScore1.ToString();
        player2ScoreText.text = "HGT : " + player2Score.endScore2.ToString();

    }
}
