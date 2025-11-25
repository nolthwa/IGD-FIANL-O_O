public class Gold : Item
{
    public int ScoreValue = 50;
    

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        GameManager.Instance.AddGold(ScoreValue);
        

        Destroy(gameObject);
    }
}
