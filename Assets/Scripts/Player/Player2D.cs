using UnityEngine;
using UnityEngine.Tilemaps;

public class Player2D : Entity2D
{
    [Header("Movement Settings")]
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
    private bool _isGrounded = false;
    public bool IsGrounded => _isGrounded;
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
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
    public void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + _checkGrounOffsetY), _checkGroundRadius);

        int entityCount = 0;

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent<Entity2D>(out var entity))
            {
                entityCount++;
            }
                
        }
        _isGrounded = (colliders.Length - entityCount) > 0;
    }

    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + _checkGrounOffsetY), _checkGroundRadius);
    }
    #endif
}
