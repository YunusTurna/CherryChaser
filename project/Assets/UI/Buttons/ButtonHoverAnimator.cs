using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverAnimator : MonoBehaviour
{
    public Animator animator;

    void OnMouseEnter()
    {
            animator.enabled = true;
            animator.Play("move");
    }

    void OnMouseExit()
    {
        animator.enabled = true;
        animator.Play("sidekick");
    }
}