using UnityEngine;

public class WinnerCup : MonoBehaviour
{
    [SerializeField] private GameObject loseMenu;
    [SerializeField] private GameObject winner;
    private LoseMenu _loseMenu;

    private void Start()
    {
        _loseMenu = loseMenu.GetComponent<LoseMenu>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.UnbindCamera();
            winner.SetActive(false);
            _loseMenu.HeaderText.text = "Victory!";
            loseMenu.SetActive(true);
            GameManager.Instance.winnerSound.Play();
            Time.timeScale = 0;
        }
    }
}
