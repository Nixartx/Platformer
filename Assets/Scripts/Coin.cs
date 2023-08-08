using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _parentContainer;

    private void Start()
    {
        GameManager.Instance.coinsContainer.Add(gameObject, this);
    }

    public void StartDestroy()
    {
        GameManager.Instance.coinsContainer.Remove(gameObject);
        GameManager.Instance.pickUpSound.Play();
        _animator.SetTrigger("CoinDestroy");
    }

    public void Destroy()
    {
        Destroy(_parentContainer);
    }
}
