using UnityEngine;

[RequireComponent(typeof(PlayerSwordAttackState))]

public class PlayerSwordAttackTransition : Transition
{
    private float _resetTime = 0.25f;
    private float _elapsedTime = 0f;
    private PlayerSwordAttackState _attackState;

    private void Awake()
    {
        _attackState = GetComponent<PlayerSwordAttackState>();
    }

    private void Start()
    {
        _elapsedTime = _resetTime;
    }

    public override bool IsConditionMet()
    {
        _elapsedTime += Time.deltaTime;

        if (_attackState.IsBeingExecuted)
            return true;

        if (_elapsedTime >= _resetTime && Input.GetMouseButtonDown(0))
        {
            _elapsedTime = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }
}