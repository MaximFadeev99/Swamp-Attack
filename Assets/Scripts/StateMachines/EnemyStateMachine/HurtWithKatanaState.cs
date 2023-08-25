using System.Threading.Tasks;
using UnityEngine;

public class HurtWithKatanaState : HurtState
{
    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.NinjaHurtWithKatana;
    }
      
    public override void Enter()
    {
        float durationModifier = 0.5f;
        float pushStrength = -4f;

        enabled = true;
        IsBeingExecuted = true;
        Animator.Play(AnimationCode);
        ClipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length * durationModifier;
        Rigidbody.velocity = new Vector2(pushStrength, 0);              
    }
}