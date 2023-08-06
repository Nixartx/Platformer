using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject parentContainer;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public int health;
    private int maxHealth;
    public int CurrentHealth
    {
        get { return health; }
    }

    private void Start()
    {
        maxHealth = health;
        GameManager.Instance.healthContainer.Add(gameObject,this);
    }

    public void SetHealth(int hp)
    {
        health += hp;
        if (health >= maxHealth)
            health = maxHealth;
    }

    public void TakeHit(int damage)
    {
        health -= damage;
        _animator.SetTrigger("GetDamage");
        if (health <= 0) BecomeDead();
    }

    private void BecomeDead()
    {
        _animator.SetBool("Death", true);
        Quaternion angle = _spriteRenderer.flipX ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        var prefab = Instantiate(deadPrefab, transform.position, angle, null);
        Destroy(parentContainer);
    }
}
