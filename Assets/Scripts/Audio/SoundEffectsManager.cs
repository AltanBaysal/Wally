
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    [SerializeField] private Dictionary<string, AudioClip> soundEffects = new Dictionary<string, AudioClip>();

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(string action)
    {
        AudioClip clip = GetSoundEffect(action);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"Sound effect for action '{action}' not found.");
        }
    }

    private AudioClip GetSoundEffect(string action)
    {
        if (soundEffects.TryGetValue(action, out AudioClip clip))
        {
            return clip;
        }
        return null;
    }

    public void TriggerEnemySound(Transform enemyTransform)
    {
        // Example placeholder for enemy actions
        if (enemyTransform != null)
        {
            // Determine enemy state here; just an example
            if (enemyTransform.CompareTag("Enemy"))
            {
                PlaySound("EnemyAttack"); // Replace with actual state-based sound effect
            }
        }
    }
}
