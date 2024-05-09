using UnityEngine;

public class InteractionButton : MonoBehaviour
{
    private void OnEnable()
    {
        DialogWindow.OnDialogStarted += () =>
        {
            gameObject.SetActive(false);
        };
    }
     private void OnDisable()
    {
        DialogWindow.OnDialogStarted -= () =>
        {
            gameObject.SetActive(false);
        };
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }

}
