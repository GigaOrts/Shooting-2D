using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _spawnPointsParent;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private TargetLocator _targetLocator;

    private Pool<Enemy> _pool;

    private Vector3[] _spawnPositions;
    private Timer _timer;
    
    private void Awake()
    {
        _pool = new Pool<Enemy>(_prefab, transform, 0);
        _timer = new Timer();
        
        _spawnPositions = new Vector3[_spawnPointsParent.childCount];

        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            _spawnPositions[i] = _spawnPointsParent.GetChild(i).position;
        }
    }

    private void Update()
    {
        _timer.ComputeTime(Time.deltaTime, _spawnDelay, Spawn);
    }

    public void Spawn()
    {
        Enemy enemy = _pool.Peek();
        
        enemy.SetTarget(_targetLocator.Target);
        enemy.transform.position = _spawnPositions[Random.Range(0, _spawnPositions.Length)];
    }
}
