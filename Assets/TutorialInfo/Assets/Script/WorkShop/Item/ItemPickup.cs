using UnityEngine;
using System;

public class ItemPickup : Item
{
    public enum ItemType { Coin, Gold, Token }
    public ItemType itemType;

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

            switch (itemType)
            {
                case ItemType.Coin:
                    GameManager.Instance.AddCoin(ScoreValue);
                    break;

                case ItemType.Gold:
                    GameManager.Instance.AddGold(ScoreValue);
                    break;

                case ItemType.Token:
                    GameManager.Instance.AddToken(ScoreValue);
                    break;
            }

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
