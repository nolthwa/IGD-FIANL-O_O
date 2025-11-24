using UnityEngine;

public class CollectableItem : Item
{
    public override void OnCollect(Player player)
    {
        base.OnCollect(player);
        // do something
    }
}