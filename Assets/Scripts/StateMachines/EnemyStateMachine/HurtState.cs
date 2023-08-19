using UnityEngine;

public class HurtState : State
{
    protected float ClipDuration;

    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.NinjaHurt;
        HasExitTime = true;
    }

    protected void Update()
    {
        ClipDuration -= Time.deltaTime;

        if (ClipDuration <= 0)
            Exit();
    }

    public override void Enter()
    {
        float durationModifier = 0.5f;
        float pushStrength = -3;

        base.Enter();
        Rigidbody.velocity = new Vector2(pushStrength, 0);
        ClipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length * durationModifier;      
    }
}