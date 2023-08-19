using UnityEngine;
using System.Threading.Tasks;

public class PlayerCastState : State
{
    [SerializeField] private Fireball _fireball;
    
    private float _clipDuration;

    protected override void Awake()
    {
        base.Awake();
        AnimationCode = AnimatorParameters.PlayerCast;
        HasExitTime = true;
    }

    private void Update()
    {
        _clipDuration -= Time.deltaTime;

        if (_clipDuration < 0)
            Exit();
    }

    public override void Enter()
    {
        base.Enter();
        _clipDuration = Animator.GetCurrentAnimatorClipInfo(0).Length;
        DelayAndInstantiate();
    }

    private async void DelayAndInstantiate() 
    {
        int delayTime = 500;
        float xOffset = 0.3f;
        float yOffset = 0.7f;

        await Task.Delay(delayTime);
        Instantiate
            (_fireball, 
            new Vector3 (transform.position.x - xOffset, transform.position.y - yOffset, 0), 
            transform.rotation);
    }
}