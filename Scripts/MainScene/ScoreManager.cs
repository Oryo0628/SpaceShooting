using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public static void AddScore(int value)
    {
        score += value;
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }
}
