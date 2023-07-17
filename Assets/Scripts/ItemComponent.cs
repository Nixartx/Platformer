using System;
using System.Collections;
using System.Collections.Generic;
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
    ArmorPotion = 2,
    PowerPotion = 3
}