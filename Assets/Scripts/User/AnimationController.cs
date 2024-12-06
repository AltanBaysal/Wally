
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator uiButtonAnimator;
    [SerializeField] private Animator resourceUpdateAnimator;

    public void PlayButtonHoverEffect()
    {
        uiButtonAnimator.SetTrigger("Hover");
    }

    public void PlayResourceUpdateAnimation()
    {
        resourceUpdateAnimator.SetTrigger("ResourceUpdate");
    }

    public void PlayAlertAnimation()
    {
        resourceUpdateAnimator.SetTrigger("Alert");
    }
}
