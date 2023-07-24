using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;

    private void Start()
    {
        _health.OnTakeHit += TakeHit;
    }

    private void TakeHit()
    {
        _animator.SetTrigger("GetDamage");
    }
}
