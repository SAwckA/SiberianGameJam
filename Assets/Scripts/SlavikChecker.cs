using System;
using UnityEngine;

public class SlavikChecker : MonoBehaviour
{
    [SerializeField] private bool _isFrogVisible;
    private void Start()
    {
        EventBus.playerSetInvisible += OnPlayerSetInvisible;

        gameObject.SetActive(_isFrogVisible);
    }

    private void OnDestroy()
    {
        EventBus.playerSetInvisible -= OnPlayerSetInvisible;
    }

    private void OnPlayerSetInvisible(bool isPlayerVisible)
    {
        Debug.Log(gameObject.name + (_isFrogVisible && !isPlayerVisible));
        gameObject.SetActive(!_isFrogVisible && !isPlayerVisible);
        _isFrogVisible = !_isFrogVisible && !isPlayerVisible;
    }
}
