using UnityEngine;

[RequireComponent(typeof(DisturbedState))]

public class BushIdleTransition : Transition
{
    private DisturbedState _disturbedState;

    public void Awake()
    {
        _disturbedState = GetComponent<DisturbedState>();
    }

    public override bool IsConditionMet()
    {
        return !_disturbedState.IsBeingExecuted;
    }
}