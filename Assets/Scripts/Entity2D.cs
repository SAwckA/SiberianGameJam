using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity2D : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected bool _isFacingRight = true;
    protected float _horizontalMove = 0f;
    public float HorizontalMove => _horizontalMove;

    public bool IsFacingRight => Mathf.Sign(transform.localScale.x) > -1;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    public virtual void Flip()
    {        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
