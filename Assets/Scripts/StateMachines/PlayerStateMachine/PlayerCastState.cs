using UnityEngine;
using System.Threading.Tasks;

public class PlayerCastState : State
{
    [SerializeField] private Fireball _fireball;
    
    private float _clipDuration;
    private Vector2 _instantiantionPosition;

    protected override void Awake()
    {
        float xOffset = 0.3f;
        float yOffset = 0.3f;
       
        base.Awake();
        _instantiantionPosition = new Vector2
            (transform.position.x - xOffset, transform.position.y - yOffset);
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
        int timeDelay = 700;

        await Task.Delay(timeDelay);
        Instantiate (_fireball, _instantiantionPosition, transform.rotation);
    }
}