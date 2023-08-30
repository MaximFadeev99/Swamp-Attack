using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Rigidbody2D))]

public class Arrow : Weapon
{
    [SerializeField] private GameObject _hitSparks;
    
    private int _hitCount = 1;
    private bool _isTargetReached = false;
    private Rigidbody2D _rigidbody;
    private float _maxRotation = 180;
    private float _minRotation = 160;
    private float _currentRotation;

    public Arrow() : base(50f, 35f, $"Steel Arrows. Useless without a bow.") { }

    private void Awake()
    {       
        _currentRotation = _maxRotation;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float flySpeed = -1.5f;
        float rotationChange = 0.01f;
        float gravityChange = 0.1f;

        _rigidbody.AddForce(new Vector2(flySpeed,0), ForceMode2D.Impulse);

        if (_isTargetReached == false)
        {
            _currentRotation = Mathf.Lerp(_currentRotation, _minRotation, rotationChange);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -_currentRotation));
            _rigidbody.gravityScale += gravityChange;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) && _hitCount > 0)
        {
            _isTargetReached = true;
            _hitCount--;
            Instantiate(_hitSparks, collision.gameObject.transform.position, transform.rotation);
            enemy.TakeDamage(BasicDamage);
            Destroy(gameObject);
        }
        else if (collision.TryGetComponent(out Ground ground))
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.gravityScale = 0f;
            _isTargetReached = true;
            _hitCount--;
            WaitAndDestroy();
        }
    }

    private async void WaitAndDestroy() 
    {
        int delayTime = 3000;
        
        await Task.Delay(delayTime);
        Destroy(gameObject);
    }
}
