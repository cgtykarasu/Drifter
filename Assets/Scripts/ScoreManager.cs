using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int _score = 0;
    int _highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    public int GetScore => _score;

    void Start()
    {
        _highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = _score.ToString() + " POINTS";
        highScoreText.text = "HIGH SCORE : " + _highScore.ToString();
    }

    public void AddScore(int score)
    {
        _score += score;
        scoreText.text = _score.ToString() + " POINTS";

        if (_score > _highScore)
        {
            // _highScore = _score;
            // highScoreText.text = "HIGH SCORE : : " + _highScore.ToString();
            PlayerPrefs.SetInt("highScore", _score);
        }
    }
}