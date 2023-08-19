using UnityEngine;

public class CastFireballState : State
{
    [SerializeField] private EnemyFireball _fireBall;

    private float _clipDuration;
    
    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.NinjaCast; 
        HasExitTime = true;
    }

    private void Update()
    {
        _clipDuration -= Time.deltaTime;

        if (_clipDuration <= 0 ) 
            Exit();
    }

    public override void Enter()
    {
        float clipDurationModifier = 0.8f;
        float xOffset = 0.2f;

        base.Enter();
        Instantiate(_fireBall, new Vector2(transform.position.x + xOffset, transform.position.y), transform.rotation);
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length * clipDurationModifier;
    }
}