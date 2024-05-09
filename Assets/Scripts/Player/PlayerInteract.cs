using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Update()
    {
        if(!_button || !_button.IsActive()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {  
            _button.onClick?.Invoke();
        }
    }

}
