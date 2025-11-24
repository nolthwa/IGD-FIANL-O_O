using TMPro;
using UnityEngine;
using UnityEngine.UI;

// กำหนดให้เป็น sealed เพื่อป้องกันการสืบทอด
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
    public int currentScore = 0;
    public bool isGamePaused = false;

    [Header("UI Game")]
    public GameObject pauseMenuUI;
    public TMP_Text scoreText;
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

    public void AddScore(int amount)
    {
        currentScore += amount;

        if (scoreText != null)
            scoreText.text = currentScore.ToString();
        else
            Debug.LogWarning("scoreText reference is missing.");
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