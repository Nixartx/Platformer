using System;
using System.Collections;
using System.Collections.Generic;
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
        _animator.SetTrigger("CoinDestroy");
    }

    public void Destroy()
    {
        Destroy(_parentContainer);
    }
}
