using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInteraction : BaseInteraction
{
    [SerializeField] protected int sceneNumber;

    protected override void OnClick()
    {
        Player2D player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2D>();
        SceneManager.LoadScene(sceneNumber);
    }
}
