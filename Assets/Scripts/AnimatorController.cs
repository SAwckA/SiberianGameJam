
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private IHaveHorizontalMovement entity;

    private void Awake()
    {
        entity = GetComponent<IHaveHorizontalMovement>();
    }

    private void Update()
    {
        animator.SetFloat("HorizontalMove", Mathf.Abs(entity.HorizontalMove()));
    }


}
