using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IObgectDestroy
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force = 1;
    [SerializeField] private float _lifeTime;

    [SerializeField] private TriggerDamage _triggerDamage;
    private Player player;
    public float Force
    {
        get => _force;
        set => _force = value;
    }

    
    public void SetImpulse(Vector2 direction, Player player)
    {
        this.player = player;
        _triggerDamage.Init(this);
        _triggerDamage.Parent = player.gameObject; 
        _rigidbody.AddForce(direction * _force, ForceMode2D.Impulse);
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
        
    }

    public void Destroy(GameObject gameObject)
    {
        gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        gameObject.transform.position = gameObject.transform.parent.transform.position;
        gameObject.SetActive(false);
    }
}
