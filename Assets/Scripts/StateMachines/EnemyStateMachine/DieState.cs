using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class DieState : State
{
    private Enemy _enemy;
    private Player _player;
    private float _clipDuration;

    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.NinjaDie;
        _enemy = GetComponent<Enemy>();
        HasExitTime = true;
    }

    private void OnEnable()
    {
        _player = _enemy.Player;
    }

    protected void Update()
    {
        _clipDuration -= Time.deltaTime;

        if (_clipDuration <= 0) 
        {
            Exit();
            gameObject.SetActive(false);
            _enemy.ResetToDefault();
        }            
    }

    public override void Enter()
    {
        float pushStrength = -3;

        base.Enter();
        Rigidbody.velocity = new Vector2(pushStrength, 0);
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length;
        _player.AddCoins(_enemy.Reward);
    }
}
