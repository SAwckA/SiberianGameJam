using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractionButtonListener : MonoBehaviour
{

    [SerializeField] Button target;


    void Awake() {
        EventBus.showInteractionButton += Show;
        EventBus.hideIteractionButton += Hide;
        EventBus.showInteractionButtonWithSameState  += Show;
        Hide();
    }

    void OnDestroy() {
        EventBus.showInteractionButton -= Show;
        EventBus.hideIteractionButton -= Hide;
        EventBus.showInteractionButtonWithSameState  -= Show;
    }

    void Hide() {
        target.gameObject.SetActive(false);
    }

    void Show(UnityAction onClick) 
    {
        target.gameObject.SetActive(true);
        target.onClick.RemoveAllListeners();
        target.onClick.AddListener(onClick);
    }

    void Show()
    {
        target.gameObject.SetActive(true);
    }

}
