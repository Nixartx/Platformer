using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _headerText;
    public TMP_Text HeaderText => _headerText;

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
