using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(KatanaAttackState))]

public class HurtTransition : Transition
{
    protected KatanaAttackState KatanaAttackState;
    protected bool IsHurt = false;
    private Enemy _enemy;

    private void Awake()
    {
        KatanaAttackState = GetComponent<KatanaAttackState>();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.TookDamage += OnDamageTaken;
    }

    private void OnDisable()
    {
        _enemy.TookDamage -= OnDamageTaken;
    }

    public override bool IsConditionMet()
    {
        if (KatanaAttackState.IsAttakingWithKatana == false && IsHurt)
        {
            IsHurt = false;
            return true;
        }
        else 
        {
            IsHurt = false;
            return false;
        }        
    }

    public void OnDamageTaken() 
    {
        IsHurt = true;
    }
}