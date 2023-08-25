using System;
using UnityEngine;

public class PlayerDieState : State
{
    private float _clipDuration;

    public Action Died;

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
            Died?.Invoke();
        }
    }

    public override void Enter()
    {
        float durationModifier = 2f;

        base.Enter();
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length * durationModifier;
    }
}