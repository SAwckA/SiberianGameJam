using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2D : MonoBehaviour, IHaveHorizontalMovement
{
    [Header("Movement Settings")]
    [Range(0,100f)]
    [SerializeField] private float _speed = 8f;
    [Range(0, 100f)]
    [SerializeField] private float _jumpForce = 60f;
    private Rigidbody2D _rigidbody;
    private float _horizontalMove = 0f;
    public bool IsFacingRight => Mathf.Sign(transform.localScale.x) > -1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        SpawnerOnLoad.Instance.TrySpawn(gameObject);
    }
    public void Flip()
    {        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void UpdateVelocity()
    {
        _rigidbody.velocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
    }
    public void ApplyHorizontalMove(float axisRaw)
    {
        _horizontalMove = axisRaw * _speed;
    }
    public void Jump()
    {
        if (Mathf.Abs(_rigidbody.velocity.y) > 0.001) return;
        
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    public float HorizontalMove()
    {
        return _horizontalMove;
    }
}
