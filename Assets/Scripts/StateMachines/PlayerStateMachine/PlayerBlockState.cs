using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerBlockState : State
{
    private float _clipDuration;
    private Player _player;

    protected override void Awake()
    {
        base.Awake();
        _player = GetComponent<Player>();
        AnimationCode = AnimatorParameters.PlayerBlock;
        HasExitTime = true;
    }

    private void Update()
    {
        _clipDuration -= Time.deltaTime;

        if (_clipDuration < 0)
            Exit();
    }

    public override void Enter()
    {
        base.Enter();
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length;
        _player.IgnoreDamage();
    }
}