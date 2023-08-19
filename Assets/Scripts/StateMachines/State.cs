using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected Transition Transition;   

    protected Animator Animator;
    protected Rigidbody2D Rigidbody;
    protected int AnimationCode;

    public bool HasExitTime { get; protected set; } = false;
    public bool IsBeingExecuted { get; protected set; }

    protected virtual void Awake()
    {       
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    public State TryMakeTransition() 
    {
        return Transition.IsConditionMet() ? this : null;              
    }

    public virtual void Enter() 
    {
        enabled = true;
        IsBeingExecuted = true;
        Animator.Play(AnimationCode);
    }

    public virtual void Exit() 
    {
        IsBeingExecuted = false;
        enabled = false;
    }
}
