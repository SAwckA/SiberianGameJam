using UnityEngine;
using UnityEngine.SceneManagement;

public class SavableSceneChangeInteraction : SceneChangeInteraction
{
    [SerializeField] GameObject exitPoint;
    protected override void OnClick()
    {
        MainWorldPosition.Position = exitPoint.transform.position;
        SceneManager.LoadScene(sceneNumber);
    }
}
