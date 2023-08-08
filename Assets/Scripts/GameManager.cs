using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

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
    [SerializeField] public GameObject loseMenu;
    [SerializeField] private Camera _playerCamera;
    private LoseMenu _loseMenu;

    [SerializeField] public AudioSource hitSwordSound;
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] public AudioSource winnerSound;
    [SerializeField] public AudioSource pickUpSound;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _loseMenu = loseMenu.GetComponent<LoseMenu>();
    }

    public void UnbindCamera()
    {
        _playerCamera.transform.SetParent(null);
        _playerCamera.enabled = true;
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
        UnbindCamera();
        StartCoroutine(ShowLoseScreen());
    }
    
    IEnumerator ShowLoseScreen()
    {
        yield return new WaitForSeconds(2);
        _loseMenu.HeaderText.text = "Game Over";
        _loseSound.Play();
        loseMenu.SetActive(true);
    }

    public void OnCallMenu()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            _loseMenu.HeaderText.text = "Menu";
            loseMenu.SetActive(true);
        }else
        {
            Time.timeScale = 1;
            loseMenu.SetActive(false);
        }
    }
}