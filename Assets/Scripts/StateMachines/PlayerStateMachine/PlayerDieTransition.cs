using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerDieTransition : Transition
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public override bool IsConditionMet()
    {
        return _player.IsDead? true: false;
    }
}
