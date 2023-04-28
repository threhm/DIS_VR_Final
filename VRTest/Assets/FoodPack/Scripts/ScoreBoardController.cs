using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardController : MonoBehaviour
{
    public TMP_Text text;
    private static ScoreBoardController _instance;

    // Connects the class scope to the instance scope
    private void Awake()
    {
        _instance = this;
    }

    public static void UpdateScore()
    {
        _instance.text.text = "Current Score: " + ScoreControl.getScore().ToString();
    }
}
