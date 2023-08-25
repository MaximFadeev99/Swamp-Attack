using UnityEngine;
using UnityEngine.UI;

public class Progressbar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.NextWaveSet += OnNextWaveSet;
        _spawner.NewEnemySpawned += OnNewEnemySpawned;
    }

    private void OnDisable()
    {
        _spawner.NextWaveSet += OnNextWaveSet;
        _spawner.NewEnemySpawned -= OnNewEnemySpawned;
    }

    private void Start()
    {
        Slider.value = 0;
    }

    private void OnNextWaveSet(int newValue) 
    {
        Slider.maxValue = newValue;
        Slider.value = 0;
    }

    private void OnNewEnemySpawned() 
    {
        Slider.value += 1;
    }
}