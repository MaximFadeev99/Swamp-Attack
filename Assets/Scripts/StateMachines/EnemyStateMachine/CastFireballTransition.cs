using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class CastFireballTransition : Transition
{
    private Player _player;
    private int _maxCastCount = 1;
    private int _currentCastCount;
    private float _minRange = 7f;
    private float _maxRange = 6f;
    private float _castRange;

    private void Awake()
    {
        _castRange = Random.Range(_minRange, _maxRange);
    }

    private void OnEnable()
    {
        _currentCastCount = _maxCastCount;
    }

    private void Start()
    {
        _player = GetComponent<Enemy>().Player;
    }

    public override bool IsConditionMet()
    {
        if (_currentCastCount > 0 && _player.transform.position.x - transform.position.x <= _castRange)
        {
            _currentCastCount--;
            return true;
        }
        else 
        { 
            return false; 
        }
    }
}