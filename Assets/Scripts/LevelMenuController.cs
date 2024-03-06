using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    
    public Button[] levelButtons;
    public GameObject levelButton;

    private void Awake()
    {
        ButtonsToArray();
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }

    }

    public void OpenLevel(int levelIndex)
    {
        string levelName = "Level" + levelIndex;
        SceneManager.LoadScene(levelName);
    }
    
    void ButtonsToArray()
    {
        int childCount = levelButton.transform.childCount;
        levelButtons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            levelButtons[i] = levelButton.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
