using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = $"{score} POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}