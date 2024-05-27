using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level_1");
    }

    public void PlayIntroduction()
    {
        SceneManager.LoadSceneAsync("Introduction");
    }

    public void PlayFinal()
    {
        SceneManager.LoadSceneAsync("Final");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
