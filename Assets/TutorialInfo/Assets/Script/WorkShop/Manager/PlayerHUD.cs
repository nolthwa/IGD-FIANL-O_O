using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Slider healthSlider;   // ??? Slider ??? Inspector
    private Character player;

    private void Start()
    {
        player = FindObjectOfType<Character>(); // ?? Player ?? Scene
        if(player != null)
        {
            healthSlider.maxValue = player.maxHealth;
            healthSlider.value = player.health;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            healthSlider.value = player.health;
        }
    }
}