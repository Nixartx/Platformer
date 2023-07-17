using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    private int _coins;
    private List<Item> items;
    public List<Item> Items
    {
        get { return items; }
    }
    [SerializeField] private TMP_Text coinText;
    public BuffReciever BuffReciever;

    private void Start()
    {
        coinText.SetText($"Money: {_coins}");
        items = new List<Item>();
        GameManager.Instance.inventory = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.coinsContainer.TryGetValue(other.gameObject, out var coin))
        {
            _coins++;
            coinText.SetText($"Money: {_coins}");
            coin.StartDestroy();
        }
        if (GameManager.Instance.itemsContainer.TryGetValue(other.gameObject, out var itemComponent))
        {
            items.Add(itemComponent.Item);
            itemComponent.StartDestroy();
        }
    }
}
