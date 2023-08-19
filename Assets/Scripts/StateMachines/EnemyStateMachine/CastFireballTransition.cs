using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class CastFireballTransition : Transition
{
    private Player _player;   
    private int _castCount = 1;
    private float _minRange = 7f;
    private float _maxRange = 6f;
    private float _castRange;

    private void Awake()
    {
        _castRange = Random.Range(_minRange, _maxRange);
    }

    private void Start()
    {
        _player = GetComponent<Enemy>().Player;
    }

    public override bool IsConditionMet()
    {
        if (_castCount > 0 && _player.transform.position.x - transform.position.x <= _castRange)
        {
            _castCount--;
            return true;
        }
        else 
        { 
            return false; 
        }
    }
}