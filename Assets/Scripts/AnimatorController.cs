
using UnityEngine;

[RequireComponent(typeof(Entity2D))]
public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Entity2D entity;

    private void Awake()
    {
        entity = GetComponent<Entity2D>();
    }

    private void Update()
    {
        animator.SetFloat("HorizontalMove", Mathf.Abs(entity.HorizontalMove));
    }


}
