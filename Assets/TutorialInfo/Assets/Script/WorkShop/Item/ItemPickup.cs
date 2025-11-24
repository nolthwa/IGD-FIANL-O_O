using UnityEngine;
using System;

public class ItemPickup : Item
{
    public event Action onPickedUp;
    public AudioClip SoundPickup;
    public int ScoreValue = 10;

    public float autoDestroyTime = 5f;   

    void Start()
    {
        
        Invoke(nameof(AutoDestroy), autoDestroyTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySFX(SoundPickup);
            GameManager.Instance.AddScore(ScoreValue);

            onPickedUp?.Invoke();
            Destroy(gameObject);
        }
    }

    void AutoDestroy()
    {
        onPickedUp?.Invoke();
        Destroy(gameObject);
    }
}