using UnityEngine;
using TMPro;  // ?????? TextMeshPro

public class TimerSystem : MonoBehaviour
{
    public float startTime = 60f;   
    private float currentTime;

    public TMP_Text timerText;     
    public Character player;       

    void Start()
    {
        currentTime = startTime;
        UpdateTimerUI();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;

           
            player.TakeDamage(9999);
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        timerText.text = Mathf.Ceil(currentTime).ToString("0");
    }
}