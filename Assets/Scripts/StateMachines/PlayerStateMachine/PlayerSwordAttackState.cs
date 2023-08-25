using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerSwordAttackState : State
{
    private float _clipDuration;
    private Player _player;

    protected override void Awake()
    {
        base.Awake();
        _player = GetComponent<Player>();
        AnimationCode = AnimatorParameters.PlayerSwordAttack;
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
        float durationModifier = 0.4f;
        
        base.Enter();
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length * durationModifier;
        WaitAndDealDamage();
    }

    private async void WaitAndDealDamage() 
    {
        await Task.Delay(400);
        _player.AttackWithSword();
    }
}