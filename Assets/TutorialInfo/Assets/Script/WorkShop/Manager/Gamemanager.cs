using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public sealed class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager Instance is NULL!");
            return _instance;
        }
    }

    [Header("Game State")]
    public int coinScore = 0;
    public int goldScore = 0;
    public int tokenScore = 0;
    public int PointScore = 0;
    
    public bool isGamePaused = false;

    [Header("Timer")]
    public TMP_Text timeText;       
    [Tooltip("เวลาเริ่มต้นสำหรับนับถอยหลัง (เป็นวินาที)")]
    public float startingTime = 300f; 
    private float currentTime;      
    private bool isTimeRunning = false; 

    [Header("UI Game")]
    public GameObject pauseMenuUI;
    public GameObject gameUIPanel; 	 
    public GameObject gameOverMenuUI; 	
    
    public TMP_Text coinText;
    public TMP_Text goldText;
    public TMP_Text tokenText;
    public TMP_Text PointText;
    
    public Slider HPBar;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            
            currentTime = startingTime; 
            isTimeRunning = false;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateAllScoresUI();
    }
    
    private void Update()
    {
       
        if (isTimeRunning && !isGamePaused)
        {
            currentTime -= Time.deltaTime; 
            
            if (currentTime <= 0)
            {
                currentTime = 0f;
                isTimeRunning = false;
                GameOver(); 
            }
            
            UpdateTimerUI();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
    
    private void UpdateTimerUI()
    {
        if (timeText != null)
        {
            float displayTime = Mathf.Max(0, currentTime);
            int totalSeconds = Mathf.FloorToInt(displayTime); 

            if (totalSeconds > 60)
            {
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;
                timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else 
            {
                timeText.text = string.Format("{0:00}", totalSeconds);
            }
        }
    }

    public void ResetGameScores()
    {
        coinScore = 0;
        goldScore = 0;
        tokenScore = 0;
        PointScore = 0;
        
       
        currentTime = startingTime;
        isTimeRunning = false;
    }
    
    public void UpdateAllScoresUI()
    {
        
        if (coinText != null) coinText.text = coinScore.ToString();
        if (goldText != null) goldText.text = goldScore.ToString();
        if (tokenText != null) tokenText.text = tokenScore.ToString();
        if (PointText != null) PointText.text = PointScore.ToString();

        
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        bool isMenuScene = currentSceneName.Equals("Menu", System.StringComparison.OrdinalIgnoreCase);

        if (gameUIPanel != null)
            gameUIPanel.SetActive(!isMenuScene); 
            
        if (gameOverMenuUI != null)
            gameOverMenuUI.SetActive(false); 
        
        if (timeText != null)
        {
            if (!isMenuScene)
            {
                // ถ้าเป็น Scene เล่นเกม
                timeText.gameObject.SetActive(true); 
                
              
                if (Time.timeScale == 0f)
                {
                    Time.timeScale = 1f; 
                }

             
                currentTime = startingTime;
                
                isTimeRunning = true; 
                
               
            }
            else
            {
                // ถ้าเป็น Scene "Menu"
                isTimeRunning = false; 
                timeText.gameObject.SetActive(false); 
                currentTime = startingTime; 
               
                if (Time.timeScale == 0f) 
                {
                    Time.timeScale = 1f; 
                }
            }
        }
        
        UpdateTimerUI();
    }
    
    public void GameOver()
    {
       
        Time.timeScale = 0f; 
        
        isTimeRunning = false; 
        
        if (gameUIPanel != null)
            gameUIPanel.SetActive(false); 

        if (gameOverMenuUI != null)
            gameOverMenuUI.SetActive(true); 
    }
    
   
    public void LoadGameScene(string sceneName)
    {
        
        ResetGameScores();
       
        SceneManager.LoadScene(sceneName);
    }
    
    
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (HPBar != null)
        {
            HPBar.maxValue = maxHealth;
            HPBar.value = currentHealth;
        }
        else
        {
            Debug.LogWarning("HPBar is missing!");
        }
    }

    public void AddCoin(int amount)
    {
        coinScore += amount;
        UpdateAllScoresUI(); 
    }
    
    public void AddGold(int amount)
    {
        goldScore += amount;
        UpdateAllScoresUI();
    }

    public void AddPoint(int amount)
    {
        PointScore += amount;
        UpdateAllScoresUI();
    }
    
    public void DelPoint(int amount)
    {
        PointScore -= amount;
        UpdateAllScoresUI();
    }
    
    public void AddToken(int amount)
    {
        tokenScore += amount;
        UpdateAllScoresUI();
    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0f : 1f;

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(isGamePaused);
    }
}