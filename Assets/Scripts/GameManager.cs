using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    

    public Dictionary<GameObject, Health> healthContainer = new();
    public Dictionary<GameObject, Coin> coinsContainer = new();
    public Dictionary<GameObject, HealChest> chestHealContainer = new();
    public Dictionary<GameObject, ItemComponent> itemsContainer = new();
    public Dictionary<GameObject, BuffReciever> buffRecieversContainer = new();
    public ItemBase itemDataBase;
    [HideInInspector] public Inventory inventory;
    [SerializeField] public GameObject inventoryUI;

    private void Awake()
    {
        Instance = this;
    }

    public void OnClickPause()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            inventoryUI.SetActive(true);
        }else
        {
            Time.timeScale = 1;
            inventoryUI.SetActive(false);
        }
    }
}