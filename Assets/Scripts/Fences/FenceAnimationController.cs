
using UnityEngine;

public class FenceAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animation destructionAnimation;
    [SerializeField]
    private Animation idleAnimation;

    private void Start()
    {
        PlayIdleAnimation();
    }

    public void PlayIdleAnimation()
    {
        if (idleAnimation != null)
        {
            idleAnimation.Play();
        }
    }

    public void PlayDestructionAnimation()
    {
        SoundManager.Instance.StopAllAudio();
        if (destructionAnimation != null)
        {
            destructionAnimation.Play();
        }
    }
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopAllAudio()
    {
        // Logic to stop all playing audio
        // Example: AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        // foreach (var audioSource in audioSources) audioSource.Stop();
    }
}
