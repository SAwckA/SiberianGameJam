using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] Transform _followingTarget;
    [SerializeField, Range(0f, 1f)] float _parallaxStrength = 0.1f;
    [SerializeField] bool _isVerticalParallaxDisabled = false;

    private Vector3 _targetPrevPos;

    private void Start()
    {
        if (!_followingTarget) _followingTarget = Camera.main.transform;

        _targetPrevPos = _followingTarget.position; 
    }

    private void Update()
    {
        Vector3 delta = _followingTarget.position - _targetPrevPos;
        if (_isVerticalParallaxDisabled)
        {
            delta.y = 0f;
        }

        _targetPrevPos = _followingTarget.position;
        transform.position += delta * _parallaxStrength;
    }
}
