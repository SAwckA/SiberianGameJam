using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInteraction : BaseInteraction
{
    [SerializeField] protected int sceneNumber;

    protected override void OnClick()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
