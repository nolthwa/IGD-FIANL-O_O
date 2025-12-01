using UnityEngine;

public class ExAddPoint : Item
{
    public int ScoreValue = 5;
    

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        GameManager.Instance.AddPoint(ScoreValue);
        

        Destroy(gameObject);
    }
}
