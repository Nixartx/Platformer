using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 10;
    [SerializeField] private Animator _animator;
    private Health _health;
    private float _direction;

    public float Direction => _direction;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (GameManager.Instance.healthContainer.TryGetValue(other.gameObject, out var health))
        {
            _health = health;
            _direction = (other.transform.position - transform.position).x;
            _animator.SetFloat("Direction", Mathf.Abs(_direction));
        }
    }

    //Invoke in animation
    public void SetDamage()
    {
        if (_health!=null)
            _health.TakeHit(damage);
        _health = null;
        _direction = 0;
        _animator.SetFloat("Direction", 0);
    }
}
