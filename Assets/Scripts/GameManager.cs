using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public CharacterUIController CharacterUIController;
    private float playerMoveDirection;
    public float PlayerMoveDirection
    {
        get { return playerMoveDirection; }
        set { playerMoveDirection = value; }
    }
    [HideInInspector] public Inventory inventory;
    [SerializeField] public GameObject inventoryUI;
    [SerializeField] public GameObject LoseMenu;
    private LoseMenu _loseMenu;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoseMenu _loseMenu = LoseMenu.GetComponent<LoseMenu>();
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

    public void OnPlayerDie()
    {
        StartCoroutine(ShowLoseScreen());
    }
    
    IEnumerator ShowLoseScreen()
    {
        yield return new WaitForSeconds(2);
        _loseMenu.HeaderText.text = "Game Over";
        LoseMenu.SetActive(true);
    }

    public void OnCallMenu()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            _loseMenu.HeaderText.text = "Menu";
            LoseMenu.SetActive(true);
        }else
        {
            Time.timeScale = 1;
            LoseMenu.SetActive(false);
        }
    }
}