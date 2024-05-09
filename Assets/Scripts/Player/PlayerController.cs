using UnityEngine;

[RequireComponent(typeof(Player2D))]
public class PlayerController : MonoBehaviour
{
    private Player2D _player;

    private float HorizontalMove => _player.HorizontalMove;
    private bool IsFacingRight => _player.IsFacingRight;
    private bool IsGrounded => _player.IsGrounded;

    private void Awake()
    {
        _player = GetComponent<Player2D>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            _player.Jump();
        }

        _player.ApplyHorizontalMove(Input.GetAxisRaw("Horizontal"));

        if (HorizontalMove > 0 && !IsFacingRight)
        {
            _player.Flip();
        }
        else if (HorizontalMove < 0 && IsFacingRight)
        {
            _player.Flip();
        }
    }

    private void FixedUpdate()
    {
        _player.UpdateVelocity();
        _player.CheckGround();
    }
    
}
