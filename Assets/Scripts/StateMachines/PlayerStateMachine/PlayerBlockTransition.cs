using UnityEngine;

public class PlayerBlockTransition : Transition
{
    private float _castResetTime = 2f;
    private float _elapsedTime;

    private void Start()
    {
        _elapsedTime = _castResetTime;
    }

    public override bool IsConditionMet()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _castResetTime && Input.GetKeyDown(KeyCode.E))
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
