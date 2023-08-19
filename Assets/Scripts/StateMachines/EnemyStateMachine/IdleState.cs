public class IdleState : State
{
    protected override void Awake()
    { 
        base.Awake();
        AnimationCode = AnimatorParameters.NinjaIdle;
    }
}