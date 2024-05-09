using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class Interaction : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Header("Implenets IInteraction interface")]
    [SerializeField] private MonoBehaviour _interaction;

    private void OnValidate()
    {
        if (_interaction is IInteraction) return;

        Debug.LogWarning(_interaction.name + " must be implement " + nameof(IInteraction));
        _interaction = null;
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _button.gameObject.SetActive(true);
            _button.onClick.AddListener(((IInteraction)_interaction).OnClick);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!_button) return;

        if (other.gameObject.CompareTag("Player"))
        {
            _button.onClick.RemoveListener(((IInteraction)_interaction).OnClick);
            _button.gameObject.SetActive(false);
        }
    }
}
