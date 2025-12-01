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
            
           
            UpdateAllScoresUI(); 
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

    public void ResetGameScores()
    {
        coinScore = 0;
        goldScore = 0;
        tokenScore = 0;
        PointScore = 0;

        UpdateAllScoresUI(); 
    }
    
    public void UpdateAllScoresUI()
    {
       
        if (coinText != null) coinText.text = coinScore.ToString();
        if (goldText != null) goldText.text = goldScore.ToString();
        if (tokenText != null) tokenText.text = tokenScore.ToString();
        if (PointText != null) PointText.text = PointScore.ToString();

       
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        if (currentSceneName == "Menu") 
        {
           
            if (gameUIPanel != null)
                gameUIPanel.SetActive(false); 
        }
        else
        {
           
            if (gameUIPanel != null)
                gameUIPanel.SetActive(true); 
        }
        
        
        if (gameOverMenuUI != null)
            gameOverMenuUI.SetActive(false); 
    }
    
    public void GameOver()
    {
        Time.timeScale = 0f; 

        if (gameUIPanel != null)
            gameUIPanel.SetActive(false); 

        if (gameOverMenuUI != null)
            gameOverMenuUI.SetActive(true); 
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
}