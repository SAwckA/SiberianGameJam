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

    Vector2 pictureSize;
    Player2D player;
    IEnumerator<DialogSource.Phrase> phrasesIterator;


    void Awake() 
    {
        gameObject.SetActive(false);
        nextButton = GetComponentInChildren<Button>(true);
        textField = GetComponentInChildren<TMP_Text>(true);
        speakerImagePlaceholder = GetComponentsInChildren<Image>(true)[2];
        pictureSize = speakerImagePlaceholder.GetComponent<RectTransform>().sizeDelta;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2D>();
        EventBus.processDialog += StartDialog;
    }

    void OnDestroy() 
    {
        EventBus.processDialog -= StartDialog;
    }

    public void StartDialog(IEnumerable<DialogSource.Phrase> phrases) 
    {
        gameObject.SetActive(true);
        player.SetControllerActive(false);
        phrasesIterator = phrases.GetEnumerator();
        nextButton.onClick.AddListener(OnNextButtonClick);
        EventBus.hideIteractionButton?.Invoke();

        OnNextButtonClick();
        
    }

    public void OnNextButtonClick()
    {
        if (phrasesIterator.MoveNext())
        {
            textField.text = phrasesIterator.Current.text;
            if (phrasesIterator.Current.sprite != null) {
                speakerImagePlaceholder.GetComponent<RectTransform>().sizeDelta = phrasesIterator.Current.sprite.bounds.size * pictureSize * 5;
                speakerImagePlaceholder.sprite = phrasesIterator.Current.sprite;
            } else{
                speakerImagePlaceholder.color = new Color(0, 0, 0, 0);
            }
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
