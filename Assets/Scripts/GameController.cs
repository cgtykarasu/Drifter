using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public GameOverScreen gameOverScreen;
    
    ScoreManager _scoreManager;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (gameOverScreen.isActiveAndEnabled)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void GameOver()
    {
        gameOverScreen.Setup(_scoreManager.GetScore);
    }
    
    
}
