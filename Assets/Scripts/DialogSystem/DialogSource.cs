using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DialogSource : BaseInteraction
{
    [SerializeField] string stageID;
    [SerializeField] Phrase[] phrases;

    [Serializable] public class Phrase {
        public string text;
        public Sprite sprite;
        public int setStage;
        public int onStage;
    }

    protected override void OnClick() {
        EventBus.processDialog?.Invoke(PhrasesIterator(), GetComponentInChildren<SpriteRenderer>().sprite);
    }

    private IEnumerable<Phrase> PhrasesIterator() {
        int stage = 0;
        if (PlayerPrefs.HasKey(stageID)) {
            stage = PlayerPrefs.GetInt(stageID);
        } else {
            PlayerPrefs.SetInt(stageID, stage);
        }
        foreach (Phrase phrase in phrases) {
            if (phrase.onStage == stage) {
                PlayerPrefs.SetInt(stageID, phrase.setStage);
                yield return phrase;
            }
        }
    }
}
