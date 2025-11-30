using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1; 
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1; // ??????????? (????? GameOver ?? Time.timeScale = 0)
        SceneManager.LoadScene("Menu");
    }
}