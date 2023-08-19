using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class DieTransition : Transition
{
    private Enemy _enemy;
    private bool _isDead = false;
    
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += HasDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= HasDied;
    }

    public override bool IsConditionMet()
    {
        return _isDead;
    }

    private void HasDied() 
    {
        _isDead = true;
    }
}
