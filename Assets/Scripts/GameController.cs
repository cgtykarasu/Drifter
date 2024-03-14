using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public AudioSource gameOverSound;
    ScoreManager _scoreManager;

    void Start()
    {
        SetCursorState(false);
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        SetCursorState(gameOverScreen.isActiveAndEnabled);
    }

    void SetCursorState(bool isActive)
    {
        Cursor.visible = isActive;
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void GameOver()
    {
        gameOverScreen.Setup(_scoreManager.GetScore);
        gameOverSound.Play();
    }
}