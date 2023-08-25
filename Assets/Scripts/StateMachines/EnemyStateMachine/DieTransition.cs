using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class DieTransition : Transition
{
    private Enemy _enemy;
    private bool _isDead;
    
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += HasDied;
        _isDead = false;
    }

    private void OnDisable()
    {
        _enemy.Died -= HasDied;
        _isDead = false;
    }

    public override bool IsConditionMet()
    {
        return _isDead;
    }

    private void HasDied(Enemy enemy) 
    {
        _isDead = true;
    }
}
