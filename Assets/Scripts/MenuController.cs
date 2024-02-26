using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadSceneAsync(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // public void Start()
    // {
    //     StartCoroutine(LoadSceneCouroutine());
    // }
    //
    // IEnumerator LoadSceneCouroutine()
    // {
    //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
    //     
    //     while (!asyncLoad.isDone)
    //     {
    //         float progress = Mathf.Clamp01(asyncLoad.progress / .9f);
    //         Debug.Log("Loading progress: " + progress * 100 + "%");
    //         yield return null;
    //     }
    // }

    public void QuitGame()
    {
        Application.Quit();
    }

}
