using UnityEngine;

[RequireComponent(typeof(Player2D))]
public class PlayerController : MonoBehaviour
{
    private Player2D _player;
    private bool _isJumping = false;

    private float HorizontalMove => _player.HorizontalMove();
    private bool IsFacingRight => _player.IsFacingRight;

    private void Awake()
    {
        _player = GetComponent<Player2D>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {  
            _isJumping = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumping = false;
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
        if (_isJumping)
        {
            _player.Jump();
        }
    }
    
}
