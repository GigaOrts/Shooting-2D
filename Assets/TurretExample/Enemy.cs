using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private const float PhysicsSpeedFactor = 100f;
    private Transform _target;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        _rigidbody.velocity = PhysicsSpeedFactor * _speed * Time.deltaTime * direction;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
