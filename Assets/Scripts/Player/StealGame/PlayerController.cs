using UnityEngine;
using UnityEngine.InputSystem;

namespace StealGame{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Border Cords")]
        [SerializeField] private float _lengthX;
        [SerializeField] private float _lengthY;
        [SerializeField] private Vector2 _startPosition;
        [Range(0,1f)]
        [SerializeField] private float _speed;
        private bool _isBorderOn = true;

        private void Awake()
        {
            Cursor.visible = false;
            SetStartPosition();
            
        }
        private void SetStartPosition()
        {
            Mouse.current.WarpCursorPosition(Camera.main.WorldToScreenPoint(_startPosition));
            gameObject.transform.position = _startPosition;
        }
        private void FixedUpdate()
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.F))
            {
                _isBorderOn =! _isBorderOn;
            }
            #endif

            if(_isBorderOn) ConsiderBoundaries(ref mousePosition);


            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, worldPosition, _speed);
            
        }

        private void ConsiderBoundaries(ref Vector2 mousePosition)
        {
            Vector2 vectorRight = Camera.main.WorldToScreenPoint(new Vector2(_lengthX / 2, _lengthY / 2));
            Vector2 vectorLeft = Camera.main.WorldToScreenPoint(new Vector2(-_lengthX / 2, -_lengthY / 2));
            float maxX = vectorRight.x;
            float maxY = vectorRight.y;
            float minX = vectorLeft.x;
            float minY = vectorLeft.y;

            if (mousePosition.x > maxX)
            {
                mousePosition.x = maxX;
            }
            if (mousePosition.y > maxY)
            {
                mousePosition.y = maxY;
            }
            if (mousePosition.x < minX)
            {
                mousePosition.x = minX;
            }
            if (mousePosition.y < minY)
            {
                mousePosition.y = minY;
            }
            Mouse.current.WarpCursorPosition(mousePosition);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<CircleMover>(out var _))
            {
                SetStartPosition();
            }
            else if(other.TryGetComponent<SceneLoader>(out var sceneLoader))
            {
                Cursor.visible = true;
                sceneLoader.OnClick();
            }
        }

        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(0, 0, 0), new Vector3(_lengthX, _lengthY, 0));
        }
        #endif
    }
}