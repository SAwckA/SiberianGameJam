using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player2D))]
public class WordsMinigame : MonoBehaviour
{

    private Button castSpellButton;
    private Button showMinigameButton;
    private TMP_InputField inputField;
    private bool isShowMinigame = false;

    private Player2D player;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake() 
    {
        foreach (Button button in GetComponentsInChildren<Button>()) {
            if (button.name == "CastSpellButton") {
                castSpellButton = button;
            }
            if (button.name == "ShowWordsMinigameButton") {
                showMinigameButton = button;
            }
        }
        inputField = GetComponentInChildren<TMP_InputField>();
        player = GetComponent<Player2D>();

        HideMinigameInterface();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastSpell() 
    {
        HideMinigameInterface();
        Debug.Log(inputField.text);
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
        castSpellButton.gameObject.SetActive(true);
        inputField.gameObject.SetActive(true);
        // player
        isShowMinigame = true;
    }

    private void HideMinigameInterface() 
    {
        castSpellButton.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
        isShowMinigame = false;
    }
}
