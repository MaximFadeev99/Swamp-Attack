using UnityEngine;

public class PlayerBlockTransition : Transition
{
    private float _castResetTime = 2f;
    private float _elapsedTime;
    private Player _player;

    private void Start()
    {
        _elapsedTime = _castResetTime;
        _player = GetComponent<Player>();
    }

    public override bool IsConditionMet()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _castResetTime && Input.GetKeyDown(KeyCode.E) 
            && _player.SelectedWeapon.TryGetComponent(out Sword sword))
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
