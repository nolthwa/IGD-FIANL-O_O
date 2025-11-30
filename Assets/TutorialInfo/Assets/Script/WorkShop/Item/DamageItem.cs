using UnityEngine;

public class DamageItem : Item
{
    public int damageAmount = 10;

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        player.TakeDamage(damageAmount);

        Destroy(gameObject);
    }
}
