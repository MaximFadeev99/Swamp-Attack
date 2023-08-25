using System;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public Action TookDamage;
    public Action<Enemy> Died;

    private float _maxHealth = 50f;
    private float _currentHealth;
    private float _basicDamage = 10f;
    private Player _player;

    public Player Player => _player;
    public float Reward { get; private set; } = 50f;

    private void Awake()
    {
        ResetToDefault();
    }

    public void Attack() 
    {
        _player.TakeDamage(_basicDamage);         
    }

    public void TakeDamage(float damage) 
    {
        _currentHealth -= damage;
        TookDamage?.Invoke();

        if (_currentHealth <= 0) 
            Died?.Invoke(this);            
    }

    public void SetTarget(Player player) 
    {
        _player = player;  
    }

    public void ResetToDefault()
    {
        _currentHealth = _maxHealth;
    }
}
