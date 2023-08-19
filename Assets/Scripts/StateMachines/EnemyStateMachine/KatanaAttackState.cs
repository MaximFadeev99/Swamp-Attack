using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class KatanaAttackState : State
{
    private Enemy _enemy;
    private float _clipDuration;
    private bool _isAttakingWithKatana = false;
    private float _elapsedTime = 0f;

    public bool IsAttakingWithKatana => _isAttakingWithKatana;

    protected override void Awake()
    {
        base.Awake();
        _enemy = GetComponent<Enemy>();
        AnimationCode = AnimatorParameters.NinjaKatanaAttack;
    }

    private void Update()
    {                                   
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _clipDuration) 
        {
            _enemy.Attack();
            _elapsedTime = 0f;
        }                                                            
    }

    public override void Enter() 
    {
        base.Enter();
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length;
        _isAttakingWithKatana = true;
    }
}   