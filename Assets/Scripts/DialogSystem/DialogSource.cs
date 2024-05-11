using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DialogSource : BaseInteraction
{
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
