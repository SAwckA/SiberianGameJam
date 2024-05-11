using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private Canvas _parent;
    private List<Canvas> _listOfCanvas = new List<Canvas>();
    private Player2D _player;
    

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        if (gameObject)
        {
            _player = gameObject.GetComponent<Player2D>();
        }

        _settingsMenu.SetActive(false);
    }
    

    public void OnClick()
    {
        _settingsMenu.SetActive(!_settingsMenu.activeSelf);
        if (_player) 
            _player.SetControllerActive(!_settingsMenu.activeSelf);

        if (_listOfCanvas.Count == 0)
        {
            foreach (Canvas canvas in FindObjectsOfType<Canvas>())
            {
                if (canvas == _parent) continue;

                canvas.gameObject.SetActive(!_settingsMenu.activeSelf);
                _listOfCanvas.Add(canvas);
            }
            return;
        }
        foreach (Canvas canvas in _listOfCanvas)
        {
            canvas.gameObject.SetActive(!_settingsMenu.activeSelf);
        }
        _listOfCanvas.Clear();
        

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClick();
        }
    }
}
