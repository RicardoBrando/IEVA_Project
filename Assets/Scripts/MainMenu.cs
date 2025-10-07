using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
