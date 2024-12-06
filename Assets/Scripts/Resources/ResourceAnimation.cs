
using UnityEngine;

public class ResourceAnimation : MonoBehaviour
{
    [SerializeField] private AnimationClip idleAnimation;
    [SerializeField] private AnimationClip collectionAnimation;
    [SerializeField] private AnimationClip fallingAnimation;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        // Trigger idle animation
        animator.Play(idleAnimation.name);
    }

    public void PlayCollectionAnimation()
    {
        // Trigger collection animation
        animator.Play(collectionAnimation.name);
        SoundManager.Instance.PlaySound("ResourceCollectionSound"); // Example sound method
    }

    public void PlayFallingAnimation()
    {
        // Trigger falling animation
        animator.Play(fallingAnimation.name);
    }
}
