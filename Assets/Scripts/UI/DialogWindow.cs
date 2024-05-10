
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogWindow : MonoBehaviour
{
    private Dialog.Text[] _arrayOfMsg;
    [SerializeField] private TextMeshProUGUI _textGUI;
    [SerializeField] private Button _button;
    private int _currentMsgIndex = 0;
    [SerializeField] private Image _img;
    [SerializeField] private InteractionButton _interactionButton;
    private Player2D _player;
    private void Awake()
    {
        gameObject.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2D>();
    }

    public void SetText(Dialog.Text[] texts)
    {
        _player.SetControllerActive(false);
        _interactionButton.gameObject.SetActive(false);
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
            _player.SetControllerActive(true);
            _interactionButton.gameObject.SetActive(true);
            return;
        }


        _textGUI.text = _arrayOfMsg[_currentMsgIndex].msg;
        _img.sprite = _arrayOfMsg[_currentMsgIndex].sprite;
    }
}
