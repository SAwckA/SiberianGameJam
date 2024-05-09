using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [Header("Player Search")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private string _playerTag;
    private const string DEFAULT_TAG = "Player";

    [Space]
    [Header("Camera Settings")]
    [Range(0, 1f)]
    [SerializeField] private float _moveSpeed = 0.15f;
    [Range(-10f, 10f)]
    [SerializeField] private float _offsetY = 1.7f;
    
    private void Start()
    {
        if (!_playerTransform)
        {
            if (_playerTag == "") _playerTag = DEFAULT_TAG;
            _playerTransform = GameObject.FindGameObjectWithTag(_playerTag).transform;
        }

        transform.position = SetTargetPos();
        
    }


    private void FixedUpdate()
    {
        if (!_playerTransform) return;

        Vector3 target = SetTargetPos();
        
        Vector3 pos = Vector3.Lerp(transform.position, target, _moveSpeed); 
        transform.position = pos;
    }


    private Vector3 SetTargetPos()
    {
        Vector3 target = new Vector3()
        {
            x = _playerTransform.position.x,
            y = _playerTransform.position.y + _offsetY,
            z = _playerTransform.position.z - 10,
        };
        return target;
    }
}
