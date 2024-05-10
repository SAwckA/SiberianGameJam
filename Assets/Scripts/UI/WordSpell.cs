using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WordSpell : MonoBehaviour
{
    [SerializeField] private String word;
    public String getWord() {
        return word;
    }
    
    [Serializable]
    public class SpellCastEvent : UnityEvent
    {
    }

    [SerializeField]
    private SpellCastEvent spellComsumer = new SpellCastEvent();

    public SpellCastEvent spellConsumer
    {
        get
        {
            return spellComsumer;
        }
        set
        {
            spellComsumer = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
