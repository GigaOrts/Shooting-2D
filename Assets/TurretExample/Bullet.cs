using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private const float PhysicsSpeedFactor = 100f;
    private Rigidbody2D _rigidbody;
    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _timer.ComputeTime(Time.deltaTime, _lifetime, Deactivate);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = PhysicsSpeedFactor * _speed * Time.deltaTime * transform.up;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            Deactivate();
        }
    }
}
