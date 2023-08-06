using UnityEngine;

public class HealChest : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _parentContainer;
    [SerializeField] private int bonusHeal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.Instance.chestHealContainer.ContainsKey(gameObject))
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.SetHealth(bonusHeal);
            StartDestroy();
        }
    }

    private void Start()
    {
        GameManager.Instance.chestHealContainer.Add(gameObject,this);
    }
    
    public void StartDestroy()
    {
        GameManager.Instance.chestHealContainer.Remove(gameObject);
        _animator.SetTrigger("HealChestDestroy");
    }

    public void Destroy()
    {
        Destroy(_parentContainer);
    }
}
