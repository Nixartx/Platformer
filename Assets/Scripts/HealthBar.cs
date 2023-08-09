using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private float delta;
    private Player player;
    private float lastHealth;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        lastHealth = player.Health.CurrentHealth;
    }

    private void FixedUpdate()
    {
        delta += Time.fixedDeltaTime/10;
        if(Mathf.Abs(lastHealth - player.Health.CurrentHealth) < delta)
            lastHealth = player.Health.CurrentHealth;
        
        if (lastHealth > player.Health.CurrentHealth)
            lastHealth -= delta;

        if (lastHealth < player.Health.CurrentHealth)
            lastHealth += delta;
        
        healthImage.fillAmount = lastHealth/100f;
    }
}
