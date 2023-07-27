using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void OnRestartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnExitClick()
    {
        Application.Quit();
    }
}
