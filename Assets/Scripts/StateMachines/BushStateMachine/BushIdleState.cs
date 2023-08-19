public class BushIdleState : State
{
    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.BushIdle;
    }
}