using UnityEngine;

public class Bow : Weapon
{    
    [SerializeField] private Arrow _arrow;

    public Arrow Arrow=> _arrow;

    public Vector2 ArrowSpawnPosition { get; private set; } = new Vector2(5.29f, -3.5f);

    public Bow() : base(150f, 0f, "Shabby bow. It doesn't deal damage on its own.") { }

    public void ShootArrow() 
    {
        Quaternion initialRotation = new Quaternion (0,0,180,0);

        Instantiate (_arrow, ArrowSpawnPosition, initialRotation);
    }
}