using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    public float speed;
    public float jumpForce;
    private bool _isJumpPressed;
    private float _axisX;
    [SerializeField] private GroundDetection _groundDetection;
    [SerializeField] private Arrow _arrow;
    private List<Arrow> _arrowsPull = new();
    private int _arrowCount = 3;
    [SerializeField] private Transform _arrowSpawner;
    [SerializeField] private float _cooldown = 1;
    [SerializeField] private Health _health;
    [SerializeField] private BuffReciever _buffReciever;
    public Health Health
    {
        get { return _health; }
    }
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    private bool _isCooldown;
    private bool _isJumping;
    private bool _isFalling;
    private bool _isShooting;
    

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        for (var i = 0; i < _arrowCount; i++)
        {
            var tempArrow = Instantiate(_arrow, _arrowSpawner);
            _arrowsPull.Add(tempArrow);
            tempArrow.gameObject.SetActive(false);
        }

        _buffReciever.OnBuffsChanged += TestDelegate;
    }

    private void TestDelegate()
    {
        Debug.Log("Delegate method is called");
    }

    private void Update()
    {
        _axisX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && _groundDetection.IsGrounded)
            _isJumpPressed = true;
        if (Input.GetMouseButtonDown(0) && !_isShooting)
            _isShooting = true;



    }
    private void FixedUpdate()
    {
        _playerRb.velocity = new Vector2(_axisX * speed, _playerRb.velocity.y);

        _animator.SetBool("IsGrounded", _groundDetection.IsGrounded);
        _animator.SetFloat("Speed", Mathf.Abs(_axisX * speed));
        if (_axisX > 0)
            _spriteRenderer.flipX = false;
        if (_axisX < 0)
            _spriteRenderer.flipX = true;
        
        _isJumping = _isJumping && !_groundDetection.IsGrounded;
        if (_isJumpPressed && _groundDetection.IsGrounded)
        {
            _animator.SetTrigger("StartJump");
            _isJumping = true;
            _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _isJumpPressed = false;
        }
        StartFallTrigger();
        CheckArrow();
    }

    private void StartFallTrigger()
    {
        if (!_isJumping && !_isFalling && !_groundDetection.IsGrounded)
        {
            //Because _groundDetection.IsGrounded can be true for some frames after Jump starts
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("StartJump"))
            {
                _animator.SetTrigger("StartFall");
                _isFalling = true;    
            }
        }
        if (_isFalling && _groundDetection.IsGrounded)
            _isFalling = false;
    }

    private void CheckArrow()
    {
        if (_isShooting)
        {
            if (!_isCooldown && !_animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
                _animator.SetTrigger("Shoot");
            _isShooting = false;
        }
    }

    //Starts from Player animation - Shoot
    public void Shoot()
    {
        Quaternion angle = _spriteRenderer.flipX ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        Vector2 direction = _spriteRenderer.flipX ? Vector2.left : Vector2.right;

        var arrow = _arrowsPull.Find(a => !a.gameObject.activeSelf);
        arrow.gameObject.SetActive(true);
        arrow.transform.rotation = angle;
        arrow.SetImpulse(direction, this);
                
        StartCoroutine(SetShootCooldown());
    }
    
    private IEnumerator SetShootCooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_cooldown);
        _isCooldown = false;
    }
}
