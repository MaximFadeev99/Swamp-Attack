using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerBowAttackState))]

public class PlayerBowAttackTransition : Transition
{
    private float _resetTime = 0.1f;
    private float _elapsedTime = 0f;
    private PlayerBowAttackState _bowAttackState;
    private Player _player;

    private void Awake()
    {
        _bowAttackState = GetComponent<PlayerBowAttackState>();
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

        if (_bowAttackState.IsBeingExecuted)
            return true;

        if (_elapsedTime >= _resetTime && Input.GetMouseButtonDown(0)
            && _player.SelectedWeapon.TryGetComponent(out Bow bow))
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