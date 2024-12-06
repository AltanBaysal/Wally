
using UnityEngine;

public class FenceSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip constructionSound;
    [SerializeField] private AudioClip destructionSound;
    [SerializeField] private AudioClip ambientSound;

    private AudioSource audioSource;
    
    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
    }

    public void PlayConstructionSound()
    {
        if (constructionSound != null)
        {
            audioSource.PlayOneShot(constructionSound);
        }
    }

    public void PlayDestructionSound()
    {
        if (destructionSound != null)
        {
            audioSource.PlayOneShot(destructionSound);
        }
    }

    public void PlayAmbientSound()
    {
        if (ambientSound != null && !audioSource.isPlaying)
        {
            audioSource.clip = ambientSound;
            audioSource.Play();
        }
    }

    public void StopAmbientSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
