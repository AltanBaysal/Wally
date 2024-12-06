
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    [Header("Enemy Sounds")]
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip damageSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySpawnSound()
    {
        if (spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }

    public void PlayAttackSound()
    {
        if (attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
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
