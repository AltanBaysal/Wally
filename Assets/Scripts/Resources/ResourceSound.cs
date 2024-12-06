
using UnityEngine;

[System.Serializable]
public class ResourceSound : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip harvestSound;
    public AudioClip idleSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // Loop for idle sound
        audioSource.clip = idleSound;
        audioSource.Play();
    }

    public void PlayHarvestSound()
    {
        audioSource.PlayOneShot(harvestSound);
    }

    public void PlayIdleSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = idleSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
