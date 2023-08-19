using UnityEngine;
using System.Threading.Tasks;

public class Fireball : MonoBehaviour
{
    protected float Damage = 10f;
    protected float FlySpeed = 6f;
    protected Rigidbody2D RigidBody;
    protected Animator Animator;
    protected bool IsTargetReached = false;

    private float _initialXPosition;
    private float _hitCount = 1;

    protected virtual void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();  
        Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _initialXPosition = transform.position.x;
    }

    protected virtual void Update()
    {
        float flyDistance = 8f;

        if (IsTargetReached == false) 
            RigidBody.velocity =new Vector2 (-FlySpeed,0);

        if (Mathf.Abs(transform.position.x - _initialXPosition) >= flyDistance)
            Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hitCount < 1)
            return;

        if (collision.gameObject.TryGetComponent(out Enemy enemy)) 
        {
            _hitCount--;
            enemy.TakeDamage(Damage);
            Explode();                    
        }        
    }

    protected void Explode()
    {
        IsTargetReached = true;
        RigidBody.velocity = new Vector2(0, 0);
        Animator.Play(AnimatorParameters.FireballExplosion);
        WaitAndDestroy(Animator.GetCurrentAnimatorClipInfo(0).Length);
    }

    private async void WaitAndDestroy(int duration) 
    {
        await Task.Delay(duration * 1000);
        Destroy(gameObject);
    }
}
