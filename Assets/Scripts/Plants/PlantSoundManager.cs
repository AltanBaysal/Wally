
using UnityEngine;

public class PlantSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip growthSound;
    [SerializeField] private AudioClip harvestSound;
    [SerializeField] private AudioClip damageSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayGrowthSound()
    {
        if (growthSound != null)
        {
            audioSource.PlayOneShot(growthSound);
        }
    }

    public void PlayHarvestSound()
    {
        if (harvestSound != null)
        {
            audioSource.PlayOneShot(harvestSound);
        }
    }

    public void PlayDamageSound()
    {
        if (damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }
    }
}
