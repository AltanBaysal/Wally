
using UnityEngine;

public class UserSoundManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip uiClickSound;
    [SerializeField] private AudioClip alertSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayUIClickSound()
    {
        if (uiClickSound != null)
        {
            audioSource.PlayOneShot(uiClickSound);
        }
        else
        {
            Debug.LogWarning("UI Click Sound not assigned!");
        }
    }

    public void PlayAlertSound()
    {
        if (alertSound != null)
        {
            audioSource.PlayOneShot(alertSound);
        }
        else
        {
            Debug.LogWarning("Alert Sound not assigned!");
        }
    }
}
