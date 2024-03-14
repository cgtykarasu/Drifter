using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int _score;
    private int _highScore;

    private void Awake()
    {
        instance = this;
        _highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public int GetScore => _score;

    public void AddScore(int score)
    {
        _score += score;
        UpdateScoreText();

        if (_score > _highScore)
        {
            _highScore = _score;
            UpdateHighScoreText();
            PlayerPrefs.SetInt("highScore", _score);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{_score} POINTS";
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = $"HIGH SCORE : {_highScore}";
    }
}