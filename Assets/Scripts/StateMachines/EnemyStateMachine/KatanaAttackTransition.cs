using UnityEngine;

[RequireComponent(typeof(RunTransition))]
[RequireComponent(typeof(Enemy))]

public class KatanaAttackTransition : Transition
{
    private Player _player;
    private RunTransition _runTransition;

    private void Awake()
    {
        _runTransition = GetComponent<RunTransition>();
    }

    private void Start()
    {
        _player = GetComponent<Enemy>().Player;
    }

    public override bool IsConditionMet()
    {
        return _runTransition.IsNearPlayer && _player.IsDead == false? true : false;
    }
}