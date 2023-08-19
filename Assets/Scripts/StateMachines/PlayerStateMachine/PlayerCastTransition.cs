using UnityEngine;

public class PlayerCastTransition : Transition
{
    private float _castResetTime = 1f;
    private float _elapsedTime;

    private void Start()
    {
        _elapsedTime = _castResetTime;
    }

    public override bool IsConditionMet()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _castResetTime && Input.GetMouseButtonDown(1))
        {
            _elapsedTime = 0f;
            return true;
        }
        else 
        {
            return false;
        }
    }
}
