using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerBowAttackState : State
{
    private float _clipDuration;
    private Player _player;

    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.PlayerBowAttack;
        _player = GetComponent<Player>();
        HasExitTime = true;
    }

    private void Update()
    {
        _clipDuration -= Time.deltaTime;

        if (_clipDuration < 0) 
        {
            _player.Bow.ShootArrow();
            Exit();
        }           
    }

    public override void Enter()
    {
        float durationModifier = 0.5f;

        base.Enter();
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length * durationModifier;       
    }
}
