
using UnityEngine;

public enum EnemyType
{
    Goblin,
    Orc,
    Skeleton
}

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyType enemyType;

    private void Start()
    {
        InitializeAnimator();
    }

    private void InitializeAnimator()
    {
        switch (enemyType)
        {
            case EnemyType.Goblin:
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/GoblinController");
                break;
            case EnemyType.Orc:
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/OrcController");
                break;
            case EnemyType.Skeleton:
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/SkeletonController");
                break;
        }
    }

    public void PlayIdleAnimation()
    {
        animator.SetTrigger("Idle");
    }

    public void PlayMoveAnimation()
    {
        animator.SetTrigger("Move");
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
        SoundManager.Instance.PlayAttackSound();
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("Death");
    }
}
