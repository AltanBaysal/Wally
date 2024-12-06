
using UnityEngine;

public class TowerAnimation : MonoBehaviour
{
    [SerializeField] private Animation idleAnimation;
    [SerializeField] private Animation attackAnimation;
    [SerializeField] private Animation hitAnimation;
    [SerializeField] private Animation destroyAnimation;

    public void PlayIdleAnimation()
    {
        if (idleAnimation != null)
        {
            idleAnimation.Play();
        }
    }

    public void PlayAttackAnimation()
    {
        if (attackAnimation != null)
        {
            attackAnimation.Play();
        }
    }

    public void PlayHitAnimation()
    {
        if (hitAnimation != null)
        {
            hitAnimation.Play();
        }
    }

    public void PlayDestroyAnimation()
    {
        if (destroyAnimation != null)
        {
            destroyAnimation.Play();
        }
    }
}
