
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField]
    private Collider[] triggerPoints;
    [SerializeField]
    private AudioClip audioEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySoundEffect();
        }
    }

    private void PlaySoundEffect()
    {
        //SoundEffectsManager.Instance.PlaySound(audioEffect);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Further sound adjustments can be done here if necessary
        }
    }
}