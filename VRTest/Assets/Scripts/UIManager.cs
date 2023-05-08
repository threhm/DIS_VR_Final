using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text broomScoreText;
    public TMP_Text finalScoreText;
    private static UIManager _instance;

    // Connects the class scope to the instance scope
    private void Awake()
    {
        _instance = this;
    }

    public static void UpdateScore()
    {
        _instance.broomScoreText.text = "Current Score: " + ScoreControl.getScore().ToString();
        _instance.finalScoreText.text = "Congrats! \n \n Your final score is: \n \n" + ScoreControl.getScore().ToString();
    }
}
