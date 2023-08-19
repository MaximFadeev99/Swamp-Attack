using UnityEngine;


public class DisturbedState : State
{
    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.BushDisturbed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Exit();
    }
}