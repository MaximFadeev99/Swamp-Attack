using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class IdleTransition : Transition
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Enemy>().Player;
    }

    public override bool IsConditionMet()
    {
        return _player.IsDead? true : false;
    }
}