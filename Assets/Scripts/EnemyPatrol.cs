using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float walkSpeed;
    public GameObject leftBorder;
    public GameObject rightBorder;
    
    private int _direction = 1;
    private Rigidbody2D _rb;
    private GroundDetection _groundDetection;
    private SpriteRenderer _spriteRenderer;
    private Damage _damage;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundDetection = GetComponent<GroundDetection>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _damage = GetComponent<Damage>();
    }

    private void FixedUpdate()
    {
        if (_groundDetection.IsGrounded)
        {
            _spriteRenderer.flipX = _direction < 0;
            _rb.velocity = new Vector2(_direction * walkSpeed, _rb.velocity.y);
            
        
            if (transform.position.x > rightBorder.transform.position.x || _damage.Direction < 0)
                _direction =  -Mathf.Abs(_direction);
            if (transform.position.x < leftBorder.transform.position.x || _damage.Direction > 0)         
                _direction = Mathf.Abs(_direction);    
        }
    }
}
