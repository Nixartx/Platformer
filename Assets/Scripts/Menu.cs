using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private const string PlayerNameKey = "Player_Name";
    [SerializeField] private TMP_InputField inputNameField;

    private void Start()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
            inputNameField.text = PlayerPrefs.GetString(PlayerNameKey);
    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString(PlayerNameKey, inputNameField.text);
    }



    public void OnPlayClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
