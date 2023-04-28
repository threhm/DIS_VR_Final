using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreControl
{
    public static int playerScore = 0;

    public static void incrementScore()
    {
        playerScore++;
    }

    public static int getScore()
    {
        return playerScore;
    }
}