using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class DialogSource : BaseInteraction
{
    [SerializeField] Func<bool> condition;
    [SerializeField] Phrase[] phrases;

    [Serializable] public class Phrase {
        public string text;
        public Sprite sprite;
    }

    protected override void OnClick() {
        EventBus.processDialog?.Invoke(PhrasesIterator(), GetComponentInChildren<SpriteRenderer>().sprite);
    }

    private IEnumerable<Phrase> PhrasesIterator() {
        foreach (Phrase phrase in phrases) {
            yield return phrase;
        }
    }
}
