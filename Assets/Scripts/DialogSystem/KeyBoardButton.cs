using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardButton : MonoBehaviour
{
    Button button;
    void Awake() 
    {
        button = GetComponent<Button>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            button.onClick.Invoke();
        }
    }
}
