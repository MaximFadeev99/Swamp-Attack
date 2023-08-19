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

        enabled = true;
        IsBeingExecuted = true;
        Animator.Play(AnimationCode);
        ClipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length * durationModifier;
        WaitAndPush();              
    }

    private async void WaitAndPush() 
    {
        int delayTime = 300;
        float pushStrength = -8f;

        await Task.Delay(delayTime);
        ClipDuration += delayTime / 1000;
        Rigidbody.velocity = new Vector2(pushStrength, 0);
    }
}