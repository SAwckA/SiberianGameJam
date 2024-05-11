using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteraction
{
    [SerializeField] private int _sceneNumber;

    public void OnClick()
    {
         SceneManager.LoadScene(_sceneNumber);
    }

}