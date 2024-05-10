using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteraction
{
    [SerializeField] private int _sceneNumber;
    [SerializeField] private Vector3 _scenePosition;

    public void OnClick()
    {
        // if (SpawnerOnLoad.Instance)
        //     SpawnerOnLoad.Instance.SetPosition(_scenePosition);
        // SceneManager.LoadScene(_sceneNumber);
    }

}