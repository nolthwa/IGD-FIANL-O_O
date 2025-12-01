using UnityEngine;

public class AddPoint : Item
{
    public int ScoreValue = 1;
    

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        GameManager.Instance.AddPoint(ScoreValue);
        

        Destroy(gameObject);
    }
}
