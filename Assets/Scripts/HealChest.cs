using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealChest : MonoBehaviour
{
    public int bonusHeal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if (other.gameObject.CompareTag("Player"))
        {
            health.SetHealth(bonusHeal);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameManager.Instance.chestHealContainer.Add(gameObject,this);
    }
}
