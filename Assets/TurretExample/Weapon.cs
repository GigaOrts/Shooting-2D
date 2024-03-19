using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _reloadDelay;

    [Header("Pool")]
    [SerializeField] private int _startAmount;
    [SerializeField] private Transform _container;

    private Pool<Bullet> _pool;
    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer();
        _pool = new Pool<Bullet>(_bullet, _container, _startAmount);
    }

    void Update()
    {
        transform.Rotate(0f, 0f, -Input.GetAxisRaw("Horizontal"));

        _timer.ComputeTime(Time.deltaTime, _reloadDelay, SpawnBullet);
    }

    private void SpawnBullet()
    {
        Bullet bullet = _pool.Peek();

        bullet.transform.SetPositionAndRotation(_shootPoint.position, _shootPoint.rotation);
    }
}
