using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    public GameObject levelButton;

    private void Awake()
    {
        SetInteractableButtons();
    }

    public void OpenLevel(int levelIndex)
    {
        SceneManager.LoadScene($"Level{levelIndex}");
    }
    
    void SetInteractableButtons()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        int childCount = levelButton.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Button button = levelButton.transform.GetChild(i).GetComponent<Button>();
            button.interactable = i + 1 <= levelReached;
        }
    }
}
