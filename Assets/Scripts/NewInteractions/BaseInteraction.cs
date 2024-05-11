using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class BaseInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player"){
            EventBus.showInteractionButton?.Invoke(OnClick);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player"){
            EventBus.hideIteractionButton?.Invoke();
        }
    }

    protected abstract void OnClick();

}
