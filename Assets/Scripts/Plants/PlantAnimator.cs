
using UnityEngine;

public class PlantAnimator : MonoBehaviour
{
    [SerializeField] private AnimationClip idleAnimation;
    [SerializeField] private AnimationClip growthAnimation;
    [SerializeField] private AnimationClip harvestAnimation;
    [SerializeField] private AnimationClip damageAnimation;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        animator.Play(idleAnimation.name);
    }

    public void PlayGrowthAnimation()
    {
        animator.Play(growthAnimation.name);
        UpdateAnimator();
    }

    public void PlayHarvestAnimation()
    {
        animator.Play(harvestAnimation.name);
        StartCoroutine(DisablePlantAfterAnimation());
    }

    public void PlayDamageAnimation()
    {
        animator.Play(damageAnimation.name);
    }

    private void UpdateAnimator()
    {
        // Synchronize with PlantBehavior logic here if necessary
    }

    private System.Collections.IEnumerator DisablePlantAfterAnimation()
    {
        yield return new WaitForSeconds(harvestAnimation.length);
        gameObject.SetActive(false);
    }
}
