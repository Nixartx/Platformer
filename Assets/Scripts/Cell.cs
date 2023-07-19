using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Button button;
    private Item item;
    public Action OnUpdateCell;

    private void Awake()
    {
        button.image.sprite = null;
    }

    public void Init(Item item)
    {
        
        this.item = item;
        if (item == null)
        {
            button.image.sprite = null;
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            button.image.sprite = item.Icon;
        }
                
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
        if (OnUpdateCell != null)
            OnUpdateCell();
    }
}
