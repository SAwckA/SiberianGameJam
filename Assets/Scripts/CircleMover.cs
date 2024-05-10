using UnityEngine;

public class CircleMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;

    private void Awake()
    {
        gameObject.transform.position = _startPosition;
    }
    private void FixedUpdate()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _endPosition, _speed);
        if (gameObject.transform.position == (Vector3)_endPosition)
        {
            Vector2 _ = _endPosition;
            _endPosition = _startPosition;
            _startPosition = _;
        }
    }
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(_startPosition, _endPosition);

        Gizmos.DrawIcon(_startPosition, "button.png", true);
    }

    #endif
}
