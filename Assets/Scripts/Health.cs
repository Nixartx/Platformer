using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject parentContainer;
    public int health;
    public int CurrentHealth
    {
        get { return health; }
    }

    private void Start()
    {
        GameManager.Instance.healthContainer.Add(gameObject,this);
    }

    public void SetHealth(int hp)
    {
        health += hp;
    }

    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0) BecomeDead();
    }

    private void BecomeDead()
    {
        Destroy(parentContainer);
    }
}
