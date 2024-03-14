using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class IntroScreen : MonoBehaviour
{
    private const float WaitTime = 8.5f;

    async UniTaskVoid Start()
    {
        await UniTask.Delay((int)(WaitTime * 1000));
        SceneManager.LoadScene("MainMenu");
    }
}
