
using UnityEngine;

public enum TowerType
{
    SingleTarget,
    AoE
}

public class TowerSoundManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip constructionSound;
    [SerializeField] private AudioClip upgradeSound;
    [SerializeField] private AudioClip singleTargetAttackSound;
    [SerializeField] private AudioClip aoeAttackSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip destructionSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayConstructionSound()
    {
        PlaySound(constructionSound);
    }

    public void PlayUpgradeSound()
    {
        PlaySound(upgradeSound);
    }

    public void PlayAttackSound(TowerType towerType)
    {
        AudioClip attackSound = towerType == TowerType.SingleTarget ? singleTargetAttackSound : aoeAttackSound;
        PlaySound(attackSound);
    }

    public void PlayHitSound()
    {
        PlaySound(hitSound);
    }

    public void PlayDestructionSound()
    {
        PlaySound(destructionSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Attempted to play a null audio clip.");
        }
    }
}
