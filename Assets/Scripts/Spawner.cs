using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EnemyWave> _waves;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyPool _enemyPool;

    private Vector2 _spawnPoint;
    private EnemyWave _currentWave;
    private int _spawnedEnemiesCount;
    private float _elapsedTime;

    private void Awake()
    {
        _spawnPoint = transform.position;
        _currentWave = _waves[0];
        _elapsedTime = _currentWave.SpawnDelay;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_spawnedEnemiesCount < _currentWave.SpawnCount)
        {
            if (_elapsedTime >= _currentWave.SpawnDelay) 
            {
                if(_enemyPool.TryGetIdleEnemy(out Enemy idleEnemy))
                    SpawnNextEnemy(idleEnemy);
            }               
        }
        else 
        {
            TrySetNextWave();
        }       
    }

    private void SpawnNextEnemy(Enemy spawnedEnemy) 
    {
        spawnedEnemy.gameObject.SetActive(true);
        spawnedEnemy.transform.position = _spawnPoint;
        spawnedEnemy.SetTarget(_player);
        _spawnedEnemiesCount++;
        _elapsedTime = 0f;
    }

    private void TrySetNextWave() 
    {
        _spawnedEnemiesCount = 0;

        if (_waves.IndexOf(_currentWave) + 1 < _waves.Count)
        {
            _currentWave = _waves[_waves.IndexOf(_currentWave) + 1];
        }
        else
        {
            gameObject.SetActive(false);
        }                  
    }
}

[System.Serializable]
public class EnemyWave 
{
    public Enemy EnemyPrefab;
    public float SpawnDelay;
    public int SpawnCount;
}