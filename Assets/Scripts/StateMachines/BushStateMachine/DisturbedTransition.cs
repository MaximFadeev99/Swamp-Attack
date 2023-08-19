using UnityEngine;

public class DisturbedTransition : Transition
{
    private bool _isDisturbed;

    public override bool IsConditionMet()
    {
        return _isDisturbed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isDisturbed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isDisturbed = true;
    }
}