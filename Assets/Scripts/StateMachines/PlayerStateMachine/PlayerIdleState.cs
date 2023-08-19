public class PlayerIdleState : State
{
    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.PlayerIdle;
    }
}