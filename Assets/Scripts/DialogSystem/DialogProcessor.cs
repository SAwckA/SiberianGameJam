using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogProcessor : MonoBehaviour
{
    // Start is called before the first frame update
    Button nextButton;
    TMP_Text textField;
    Image speakerImagePlaceholder;

    Player2D player;
    IEnumerator<DialogSource.Phrase> phrasesIterator;


    void Awake() 
    {
        gameObject.SetActive(false);
        nextButton = GetComponentInChildren<Button>(true);
        textField = GetComponentInChildren<TMP_Text>(true);
        speakerImagePlaceholder = GetComponentsInChildren<Image>(true)[2];

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2D>();
        EventBus.processDialog += StartDialog;
    }

    void OnDestroy() 
    {
        EventBus.processDialog -= StartDialog;
    }

    public void StartDialog(IEnumerable<DialogSource.Phrase> phrases, Sprite speakerSprite) 
    {
        gameObject.SetActive(true);
        player.SetControllerActive(false);
        phrasesIterator = phrases.GetEnumerator();
        nextButton.onClick.AddListener(OnNextButtonClick);
        EventBus.hideIteractionButton?.Invoke();

        if (phrasesIterator.MoveNext())
        {
            textField.text = phrasesIterator.Current.text;
            speakerImagePlaceholder.sprite = phrasesIterator.Current.sprite;
        } else {
            EndDialog();
        }
        
    }

    public void OnNextButtonClick()
    {
        if (phrasesIterator.MoveNext())
        {
            textField.text = phrasesIterator.Current.text;
            speakerImagePlaceholder.sprite = phrasesIterator.Current.sprite;
        }
        else
        {
            EndDialog();
        }
    }

    public void EndDialog()
    {
        gameObject.SetActive(false);
        player.SetControllerActive(true);
        nextButton.onClick.RemoveAllListeners();
        EventBus.showInteractionButtonWithSameState?.Invoke();
    }
}
