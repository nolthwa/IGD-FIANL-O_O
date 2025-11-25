using UnityEngine;

public class Token : Item
{
    public int ScoreValue = 100;
    

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        GameManager.Instance.AddToken(ScoreValue);
        

        Destroy(gameObject);
    }
}
