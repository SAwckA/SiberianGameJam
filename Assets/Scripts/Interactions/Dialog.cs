using System;
using Unity.VisualScripting;
using UnityEngine;

public class Dialog : MonoBehaviour, IInteraction
{
    
    [SerializeField] private Text[] _texts;
    
    [SerializeField] private DialogWindow _dialogWindow;

    public void OnClick()
    {
        _dialogWindow.gameObject.SetActive(true);
        _dialogWindow.SetText(_texts);

    }
    [Serializable]
    public class Text
    { 
        public string msg;
        public Sprite sprite;

    }
}



