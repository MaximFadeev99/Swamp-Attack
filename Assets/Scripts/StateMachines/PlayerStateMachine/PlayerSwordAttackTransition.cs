using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerSwordAttackState))]

public class PlayerSwordAttackTransition : Transition
{
    private float _resetTime = 0.25f;
    private float _elapsedTime = 0f;
    private PlayerSwordAttackState _attackState;
    private Player _player;

    private void Awake()
    {
        _attackState = GetComponent<PlayerSwordAttackState>();
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        _elapsedTime = _resetTime;
    }

    public override bool IsConditionMet()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return false;
        
        _elapsedTime += Time.deltaTime;

        if (_attackState.IsBeingExecuted)
            return true;

        if (_elapsedTime >= _resetTime && Input.GetMouseButtonDown(0) 
            && _player.SelectedWeapon.TryGetComponent(out Sword sword))
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