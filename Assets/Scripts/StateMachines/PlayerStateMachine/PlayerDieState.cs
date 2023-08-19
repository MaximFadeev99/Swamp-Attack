using UnityEngine;

public class PlayerDieState : State
{
    private float _clipDuration;

    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.PlayerDie;
        HasExitTime = true;
    }

    protected void Update()
    {
        _clipDuration -= Time.deltaTime;

        if (_clipDuration <= 0)
        {
            Exit();
            gameObject.SetActive(false);
        }
    }

    public override void Enter()
    {
        base.Enter();
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length;
    }
}