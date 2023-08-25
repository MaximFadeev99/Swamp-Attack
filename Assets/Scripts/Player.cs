using System;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour 
{
    private const string EnemyMaskName = "Enemy";
    private const string bow = nameof(bow);
    private const string sword = nameof(sword);

    public Action<float> HealthChanged;
    public Action<float> CoinCountChanged;

    private float _maxHealth = 200;
    private ContactFilter2D _contactFilter;
    private bool _isIgnoringDamage = false;

    public bool IsDead { get; private set; } = false;
    public float CurrentHealth { get; private set; }
    public float Coins { get; private set; } = 0;
    public Weapon SelectedWeapon { get; private set; }
    public Sword Sword { get; private set; }
    public Bow Bow { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
        Sword = transform.Find(sword).GetComponent<Sword>();
        Sword.gameObject.SetActive(false);        
        Bow = transform.Find(bow).GetComponent<Bow>();
        Bow.gameObject.SetActive(false);
        SelectedWeapon = null;
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(LayerMask.GetMask(EnemyMaskName));
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Sword.IsBought)
        {
            SwapWeapon(Sword);
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Bow.IsBought && Bow.Arrow.IsBought)
        {
            SwapWeapon(Bow);
            return;
        }
    }

    private void SwapWeapon(Weapon nextWeapon) 
    {
        if (SelectedWeapon != null)
            SelectedWeapon.gameObject.SetActive(false);

        SelectedWeapon = nextWeapon;
        SelectedWeapon.gameObject.SetActive(true);
    }

    public void TakeDamage(float incomingDamage) 
    {
        if (_isIgnoringDamage)
            return;
                   
        CurrentHealth -= incomingDamage;
        HealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0) 
        {
            IsDead = true;
            SelectedWeapon.gameObject.SetActive(false);
        }           
    }

    public void AttackWithSword() 
    {
        float damageDistance = 1.8f;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        
        for (int i = 0;  i < enemies.Length; i++) 
        {
            if (transform.position.x - enemies[i].transform.position.x <= damageDistance) 
                enemies[i].TakeDamage(SelectedWeapon.BasicDamage);
        }      
    }

    public async void IgnoreDamage() 
    {
        int resetTime = 3000;

        _isIgnoringDamage = true;
        await Task.Delay(resetTime);
        _isIgnoringDamage = false;
    }

    public void AddCoins(float addedAmount) 
    {
        if (addedAmount > 0) 
        {
            Coins += addedAmount;
            CoinCountChanged?.Invoke(Coins);
        }           
    }

    public void ActivateItem(Weapon weapon) 
    {
        weapon.IsBought = true;
        Coins -= weapon.Price; 
        CoinCountChanged?.Invoke(Coins);
    }
}