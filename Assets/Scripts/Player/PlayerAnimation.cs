
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private string currentAnimationState = "idle";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentAnimationState == newState) return;

        animator.Play(newState);
        currentAnimationState = newState;
    }

    public void UpdateAnimation(bool isMoving, string selectedTool)
    {
        if (isMoving)
        {
            ChangeAnimationState("moving");
        }
        else
        {
            ChangeAnimationState("idle");
        }

        if (selectedTool == "attack")
        {
            ChangeAnimationState("attacking");
        }
    }
}
