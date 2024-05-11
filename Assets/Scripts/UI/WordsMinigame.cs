using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordsMinigame : MonoBehaviour
{
    private Button castSpellButton;
    private Button showMinigameButton;
    private TMP_InputField inputField;
    private ParticleSystem spellParticleSystem;
    private bool isShowMinigame = false;

    private List<WordSpell> spells = new List<WordSpell>();

    private Player2D player;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake() 
    {
        foreach (Button button in GetComponentsInChildren<Button>(true)) {
            if (button.name == "CastSpellButton") {
                castSpellButton = button;
            }
            if (button.name == "ShowWordsMinigameButton") {
                showMinigameButton = button;
            }
        }

        foreach (WordSpell spell in GetComponentsInChildren<WordSpell>()) {
            spells.Add(spell);
        }

        inputField = GetComponentInChildren<TMP_InputField>(true);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2D>();

        spellParticleSystem = player.gameObject.GetComponentInChildren<ParticleSystem>();

        HideMinigameInterface();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowMinigame) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                HideMinigameInterface();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                CastSpell();
                return;
            }

        }
    }

    public void CastSpell() 
    {
        HideMinigameInterface();
        
        foreach (WordSpell spell in spells) {
            if (ClearString(spell.getWord()) == ClearString(inputField.text)) {
                spellParticleSystem.Play();
                spell.spellConsumer.Invoke();
                Debug.Log("CastSpell " + spell.getWord());
                break;
            }
        }
    }

    private String ClearString(String str) {
        return str.ToLower();
    }

    public void ToggleMinigameInterface() 
    {
        if (isShowMinigame) {
            HideMinigameInterface();
            return;
        }
        ShowMinigameInterface();
    }

    private void ShowMinigameInterface() 
    {
        EventBus.hideIteractionButton?.Invoke();
        castSpellButton.gameObject.SetActive(true);
        inputField.gameObject.SetActive(true);
        inputField.ActivateInputField();
        inputField.Select();
        player.SetControllerActive(false);
        isShowMinigame = true;
    }

    private void HideMinigameInterface() 
    {
        castSpellButton.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        player.SetControllerActive(true);
        isShowMinigame = false;
    }
}
