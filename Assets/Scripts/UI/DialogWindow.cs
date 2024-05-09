
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogWindow : MonoBehaviour
{
    private Dialog.Text[] _arrayOfMsg;
    private TextMeshProUGUI _textGUI;
    private Button _button;
    private int _currentMsgIndex = 0;
    [SerializeField] private Image _img;
    public static event Action OnDialogStarted;
    public static event Action OnDialogEnded;

    private void Awake()
    {
        _textGUI = GetComponentInChildren<TextMeshProUGUI>();
        _button = GetComponentInChildren<Button>();

        gameObject.SetActive(false);

    }

    public void SetText(Dialog.Text[] texts)
    {
        OnDialogStarted?.Invoke();
        _arrayOfMsg = texts;
        _img.sprite = _arrayOfMsg[_currentMsgIndex].sprite;
        _textGUI.text = _arrayOfMsg[_currentMsgIndex].msg;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _currentMsgIndex++;
        if (_arrayOfMsg.Length == _currentMsgIndex)
        {
            _currentMsgIndex = 0;
            _textGUI.text = "";
            _button.onClick.RemoveListener(OnButtonClick);
            gameObject.SetActive(false);
            OnDialogEnded?.Invoke();
            return;
        }


        _textGUI.text = _arrayOfMsg[_currentMsgIndex].msg;
        _img.sprite = _arrayOfMsg[_currentMsgIndex].sprite;
    }
}
