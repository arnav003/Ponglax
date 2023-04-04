using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int playerOne;
    int playerTwo;

    public TMP_Text scoreText;

    private void Start()
    {
        playerOne = 0;
        playerTwo = 0;
    }

    public void playerOneScored()
    {
        playerOne++;
        changeScore();
    }

    public void playerTwoScored()
    {
        playerTwo++;
        changeScore();
    }

    void changeScore()
    {
        scoreText.text = playerOne.ToString() + " : " + playerTwo.ToString();
    }
}
