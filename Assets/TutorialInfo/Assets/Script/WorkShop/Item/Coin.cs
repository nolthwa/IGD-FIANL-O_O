using UnityEngine;
using System;

public class Coin : Item
{
    public int ScoreValue = 10;
    public AudioClip SoundCoin;
    public override void OnCollect(Player player)
    {
        base.OnCollect(player);
        GameManager.Instance.AddScore(ScoreValue);
        SoundManager.Instance.PlaySFX(SoundCoin);
        Destroy(gameObject);

    }
}
