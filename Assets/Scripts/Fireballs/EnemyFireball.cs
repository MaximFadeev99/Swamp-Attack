using UnityEngine;

public class EnemyFireball : Fireball
{
    protected override void Awake() 
    {
        base.Awake();
        Damage = 5;
    }

    protected override void Update() 
    {
        if (IsTargetReached == false)
            RigidBody.velocity = new Vector2(FlySpeed, 0);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (HitCount < 1)
            return;

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            HitCount--;
            player.TakeDamage(Damage);
            Explode();
        }
    }
}
