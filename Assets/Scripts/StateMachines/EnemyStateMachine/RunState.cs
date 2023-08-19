using UnityEngine;

public class RunState : State
{
    private float _speed = 3;

    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.NinjaRun;       
    }

    private void FixedUpdate()
    {
       if (Transition.IsConditionMet())
       {
            Rigidbody.velocity = new Vector2(_speed, 0);
            return;
       }

        Exit();              
    }
}