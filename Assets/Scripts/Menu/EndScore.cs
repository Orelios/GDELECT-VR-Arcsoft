using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScore : MonoBehaviour
{
    [SerializeField] private ScoreManager gameScore;
    [SerializeField] private TMP_Text finalScoreText;

    void Start()
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        int finalScore = gameScore.GetScore();
        finalScoreText.text = "Score: " + finalScore;
    }

}
