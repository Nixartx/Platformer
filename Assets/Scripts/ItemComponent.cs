using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    
    [SerializeField] private ItemType type;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _parentContainer;
    private Item item;
    public Item Item
    {
        get { return item; }
    }
    
    private void Start()
    {
        GameManager.Instance.itemsContainer.Add(gameObject, this);
        item = GameManager.Instance.itemDataBase.GetItemByID((int)type);
        _spriteRenderer.sprite = item.Icon;
    }
    
    public void StartDestroy()
    {
        GameManager.Instance.itemsContainer.Remove(gameObject);
        GameManager.Instance.pickUpSound.Play();
        _animator.SetTrigger("PotionDestroy");
    }
    
    public void Destroy()
    {
        Destroy(_parentContainer);
    }
}

public enum ItemType
{
    DamagePotion = 1,
    HealthPotion = 2
    
}