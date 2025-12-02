using UnityEngine;
using TMPro;  
using System.Collections; 

public class TimerSystem : MonoBehaviour
{
    public float startTime = 60f;   
    private float currentTime;
    private bool isTimeRunning = false; 
    private bool hasTimeEnded = false; 
    
    private const float FreezeDelay = 0.2f; 
    
    private Coroutine gameOverCoroutine;

    public TMP_Text timerText;     
    public Character player;       
    
    public GameObject gameUIPanel;      
    public GameObject gameOverMenuUI;   

    void Start()
    {
       
        ResetAndStartTimer(startTime); 
    }

    void Update()
    {
       
        if (isTimeRunning && Time.timeScale != 1f)
        {
             Time.timeScale = 1f;
        }
        
        if (!isTimeRunning || hasTimeEnded) 
            return; 

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            isTimeRunning = false; 
            hasTimeEnded = true; 
            
            if (gameOverCoroutine == null)
            {
                gameOverCoroutine = StartCoroutine(HandleGameOverUI()); 
            }
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.FloorToInt(currentTime); 
            timerText.text = seconds.ToString("00");
        }
    }
    
    private IEnumerator HandleGameOverUI()
    {
        if (gameUIPanel != null)
            gameUIPanel.SetActive(false); 
            
        if (gameOverMenuUI != null)
            gameOverMenuUI.SetActive(true); 

        if (player != null)
        {
            player.TakeDamage(9999);
        }

        yield return null; 
        
        gameOverCoroutine = null; 
    }
    
    
    public void ResetAndStartTimer(float newStartTime)
    {
        // 1. สั่งหยุด Coroutine ของเกมที่แล้วทันที (ถ้ามี)
        if (gameOverCoroutine != null)
        {
            StopCoroutine(gameOverCoroutine);
            gameOverCoroutine = null; 
        }
        
      
        Time.timeScale = 1f; 
        
        if (gameOverMenuUI != null)
            gameOverMenuUI.SetActive(false); 
        if (gameUIPanel != null)
            gameUIPanel.SetActive(true); 
        
        currentTime = newStartTime;
        isTimeRunning = true; 
        hasTimeEnded = false; 
        
        UpdateTimerUI();
    }
}