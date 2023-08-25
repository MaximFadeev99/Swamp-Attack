using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Sprite _icon;

    public bool IsBought;

    public float Price { get; protected set; } 
    public string Description { get; protected set; }
    public float BasicDamage { get; protected set; }
    public Sprite Icon => _icon;

    public Weapon(float price, float basicDamage, string description) 
    {
        Price = price;
        BasicDamage = basicDamage;
        Description = description + $"\nDamage: {basicDamage}";
        IsBought = false;
    }
}
