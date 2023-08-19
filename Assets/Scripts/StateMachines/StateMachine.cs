using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] protected List<State> States;
    [SerializeField] private State _defaultState;   

    protected State CurrentState;
    protected State NextState;

    private void Start()
    {
        ResetToDefault();
    }

    protected virtual void Update()
    {
        if (CurrentState.HasExitTime && CurrentState.IsBeingExecuted)
            return;

        NextState = null;

        foreach (var state in States)
        {
            NextState = state.TryMakeTransition();

            if (NextState != null && NextState.IsBeingExecuted == false)
            {
                CurrentState.Exit();
                NextState.Enter();
                CurrentState = NextState;
                return;
            }
        }
    }

    protected void ResetToDefault()
    {
        if (CurrentState != null)
            CurrentState.Exit();

        CurrentState = _defaultState;
        CurrentState.Enter();
    }
}
