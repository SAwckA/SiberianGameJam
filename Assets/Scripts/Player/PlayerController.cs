using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
    [Header("Player Movement Settings")]
    [Range(0,100f)]
    [SerializeField] private float _speed = 8f;
    [Range(0, 100f)]
    [SerializeField] private float _jumpForce = 60f;

    [Space]

    [Header("Ground Checker Settings")]
    [Range(-5f,5f)]
    [SerializeField] private float _checkGrounOffsetY = -0.8f;
    [Range(0,5f)]
    [SerializeField] private float _checkGroundRadius = 0.41f;

    private Rigidbody2D _rigidbody;
    private bool _isFacingRight = true;
    public bool _isGrounded = false;
    private float _horizontalMove = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }


        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;

        if (_horizontalMove > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (_horizontalMove < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
        CheckGround();
    }
    private void Flip()
    {
        _isFacingRight =!_isFacingRight;
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + _checkGrounOffsetY), _checkGroundRadius);

        _isGrounded = colliders.Length > 1; // there will always be one collider, this is our character
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + _checkGrounOffsetY), _checkGroundRadius);
    }
    #endif
}
