using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    
    public string MainGame = "GameSceneName"; 
    
    
    public void Restart()
    {
       
        GameManager.Instance.ResetGameScores();
        
       
        Time.timeScale = 1; 
        
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
   
    public void GoToMainMenu()
    {
        Time.timeScale = 1; 
        
        
        SceneManager.LoadScene("Menu"); 
    }
    

    public void OnRestartButtonClicked()
    {
        
        GameManager.Instance.ResetGameScores();

       
        Time.timeScale = 1f;

       
        Restart();
    }
}