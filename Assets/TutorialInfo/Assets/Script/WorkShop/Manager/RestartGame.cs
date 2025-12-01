using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [Header("Scene Names")]
    public string MainGameSceneName = "GameSceneName"; 
    public string MainMenuSceneName = "Menu"; 

    
    // ฟังก์ชันที่ใช้ผูกกับปุ่ม Restart
    public void RestartGameButton()
    {
       
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGameScores();
        }
        
      
        Time.timeScale = 1f; 
        
       
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
   
    public void GoToMainMenu()
    {
        
        if (GameManager.Instance != null)
        {
            
            GameManager.Instance.GameOver(); 
           
             GameManager.Instance.ResetGameScores();
        }
        
       
        Time.timeScale = 1f; 

       
        SceneManager.LoadScene(MainMenuSceneName); 
    }
}