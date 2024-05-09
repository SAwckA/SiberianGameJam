using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class Interaction : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Header("Implenets IInteraction interface")]
    [SerializeField] private MonoBehaviour _interection;

    private void OnValidate()
    {
        if (_interection is IInteraction) return;

        Debug.LogWarning(_interection.name + " must be implement " + nameof(IInteraction));
        _interection = null;
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _button.gameObject.SetActive(true);
            _button.onClick.AddListener(((IInteraction)_interection).OnClick);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!_button) return;

        if (other.gameObject.CompareTag("Player"))
        {
            _button.onClick.RemoveListener(((IInteraction)_interection).OnClick);
            _button.gameObject.SetActive(false);
        }
    }
}
