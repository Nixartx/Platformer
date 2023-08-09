using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private float delta;
    private float dynamicDelta;
    private Player player;
    private float lastHealth;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        lastHealth = player.Health.CurrentHealth;
    }

    private void FixedUpdate()
    {
        dynamicDelta = delta * Time.fixedDeltaTime;
        if(Mathf.Abs(lastHealth - player.Health.CurrentHealth) < dynamicDelta)
            lastHealth = player.Health.CurrentHealth;
        
        if (lastHealth > player.Health.CurrentHealth)
            lastHealth -= dynamicDelta ;

        if (lastHealth < player.Health.CurrentHealth)
            lastHealth += dynamicDelta;
        
        healthImage.fillAmount = lastHealth/100f;
    }
}
