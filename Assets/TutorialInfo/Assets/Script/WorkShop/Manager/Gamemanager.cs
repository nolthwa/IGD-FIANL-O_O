using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ��˹������ sealed ���ͻ�ͧ�ѹ����׺�ʹ
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
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
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
        coinText.text = coinScore.ToString();
    }
    

    public void AddGold(int amount)
    {
        goldScore += amount;
        goldText.text = goldScore.ToString();
    }

    public void AddPoint(int amount)
    {
        PointScore += amount;
        PointText.text = PointScore.ToString();
    }
    
    public void DelPoint(int amount)
    {
        PointScore -= amount;
        PointText.text = PointScore.ToString();
    }
    public void AddToken(int amount)
    {
        tokenScore += amount;
        tokenText.text = tokenScore.ToString();
    }
    public void UpdateAllScoresUI()

    {       
    if (PointText != null)
        PointText.text = PointScore.ToString();
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
    public void ResetGameScores()

    {
    PointScore = 0;
    UpdateAllScoresUI(); 
    
    Debug.Log("Scores have been reset to 0.");
    }


}