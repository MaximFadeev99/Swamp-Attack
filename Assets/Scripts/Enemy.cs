using System;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public Action TookDamage;
    public Action Died;

    private float _maxHealth = 50f;
    private float _currentHealth;
    private float _basicDamage = 10f;
    private Player _player; 
    
    public Player Player => _player;

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
            Died?.Invoke();
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
