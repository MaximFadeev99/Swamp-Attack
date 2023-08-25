using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EnemyWave> _waves;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyPool _enemyPool;

    public Action WaveEnded;
    public Action<int> NextWaveSet;
    public Action NewEnemySpawned;
    public Action LastWaveKilled;
    
    private Vector2 _spawnPoint;
    private EnemyWave _currentWave;
    private int _spawnedEnemiesCount;
    private float _elapsedTime;
    private int deathToll = 0;

    public EnemyWave CurrentWave => _currentWave;
    public int WavesCount => _waves.Count;

    private void Awake()
    {
        _spawnPoint = transform.position;
        _currentWave = _waves[0];
        NextWaveSet?.Invoke(_currentWave.SpawnCount);
        _elapsedTime = _currentWave.SpawnDelay;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_spawnedEnemiesCount < _currentWave.SpawnCount)
        {
            if (_elapsedTime >= _currentWave.SpawnDelay) 
            {
                if(_enemyPool.TryGetIdleEnemy(out Enemy idleEnemy) && idleEnemy != null) 
                {
                    SpawnNextEnemy(idleEnemy);
                    NewEnemySpawned?.Invoke();

                    if (_waves.IndexOf(_currentWave) == _waves.Count - 1) 
                        idleEnemy.Died += CountDead;                      
                }                   
            }               
        }
        else 
        {
            WaveEnded?.Invoke();
            gameObject.SetActive(false);
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

    public void TrySetNextWave() 
    {
        _spawnedEnemiesCount = 0;

        if (_waves.IndexOf(_currentWave) + 1 < _waves.Count)
        {
            _currentWave = _waves[_waves.IndexOf(_currentWave) + 1];
            gameObject.SetActive(true);
            NextWaveSet?.Invoke(_currentWave.SpawnCount);
        }
    }

    private void CountDead(Enemy enemy) 
    {
        deathToll++;
        enemy.Died -= CountDead;

        if (deathToll == _waves[_waves.Count - 1].SpawnCount)           
            LastWaveKilled?.Invoke();            
    }
}

[System.Serializable]
public class EnemyWave 
{
    public Enemy EnemyPrefab;
    public float SpawnDelay;
    public int SpawnCount;
}