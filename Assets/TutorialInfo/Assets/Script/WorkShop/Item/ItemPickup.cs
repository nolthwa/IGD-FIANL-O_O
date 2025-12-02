using UnityEngine;
using System;

public class ItemPickup : Item
{
    public enum ItemType { Coin, Gold, Token, DamageItem }
    public ItemType itemType;

    public event Action onPickedUp;
    public AudioClip SoundPickup;
   
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
