using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSource : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player"){
            EventBus.continueTeleport?.Invoke(OnClick());
            canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player"){
            EventBus.continueTeleport?.Invoke(OnClick());
        }
    }

    protected IEnumerable<DialogSource.Phrase> OnClick()
    {
        yield return new DialogSource.Phrase("Вы уверены, что хотите продолжить путь?");
        yield return new DialogSource.Phrase("Вот он, прыжок в неизвестность");
    }
}
