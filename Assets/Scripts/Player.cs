using System;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour 
{
    private const string EnemyMaskName = "Enemy";

    private float _maxHealth = 200;
    private float _currentHealth;
    private ContactFilter2D _contactFilter;
    private bool _isIgnoringDamage = false;

    public bool IsDead { get; private set; } = false;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(LayerMask.GetMask(EnemyMaskName));
    }

    public void TakeDamage(float incomingDamage) 
    {
        if (_isIgnoringDamage)
            return;
                   
        _currentHealth -= incomingDamage;

        if (_currentHealth <= 0) 
            IsDead = true;
    }

    public void AttackWithSword() 
    {
        float damage = 10f;
        float damageDistance = 1.8f;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        
        for (int i = 0;  i < enemies.Length; i++) 
        {
            if (transform.position.x - enemies[i].transform.position.x <= damageDistance) 
                enemies[i].TakeDamage(damage);
        }      
    }

    public async void IgnoreDamage() 
    {
        int resetTime = 3000;

        _isIgnoringDamage = true;
        await Task.Delay(resetTime);
        _isIgnoringDamage = false;
    }
}