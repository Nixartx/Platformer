using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image image;
    private Item item;

    private void Awake()
    {
        image.sprite = null;
    }

    public void Init(Item item)
    {
        gameObject.SetActive(true);
        this.item = item;
        image.sprite = item.Icon;
        
    }

    public void OnClickCell()
    {
        if (item == null)
            return;
        GameManager.Instance.inventory.Items.Remove(item);
        Buff buff = new Buff
        {
            type = item.Type,
            additiveBinus = item.Value
        };
        
        GameManager.Instance.inventory.BuffReciever.AddBuff(buff);
    }
}
