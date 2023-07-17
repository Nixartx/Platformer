using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _isDestroyAfterCollision;
    private GameObject _parent;
    private IObgectDestroy destroyer;

    public GameObject Parent
    {
        get => _parent;
        set => _parent = value;
    }
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public void Init(IObgectDestroy destroyer)
    {
        this.destroyer = destroyer;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _parent ||
            GameManager.Instance.coinsContainer.ContainsKey(other.gameObject) ||
            GameManager.Instance.chestHealContainer.ContainsKey(other.gameObject))
        {
            return;
        } 
            
        
        if (GameManager.Instance.healthContainer.TryGetValue(other.gameObject, out var health))
            health.TakeHit(_damage);

        if (_isDestroyAfterCollision)
        {
            if (destroyer == null)
                Destroy(gameObject);
            else
                destroyer.Destroy(gameObject);
            
        }
            
    }
}

public interface IObgectDestroy
{
    void Destroy(GameObject gameObject);
}
