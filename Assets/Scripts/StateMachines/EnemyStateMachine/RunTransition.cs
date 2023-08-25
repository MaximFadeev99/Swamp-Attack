using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class RunTransition : Transition
{
    private Player _player;
    private float _maxProximity = 0.73f;
    private float _minProximity = 0.65f;
    private float _proximityModifier;

    public bool IsNearPlayer = false;    

    private void Awake()
    {
        _proximityModifier = Random.Range(_maxProximity, _minProximity);
    }

    private void Start()
    {
        _player = GetComponent<Enemy>().Player;
    }

    public override bool IsConditionMet()
    {
        if (transform.position.x < _player.transform.position.x * _proximityModifier && _player.IsDead == false)
        {
            IsNearPlayer = false;
            return true;
        }
        else
        {
            IsNearPlayer = true;
            return false;
        }
    }
}