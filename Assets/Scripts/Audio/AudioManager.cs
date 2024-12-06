
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] dayMusicTracks;
    [SerializeField] private AudioClip[] nightMusicTracks;
    [SerializeField] private Transform player;
    private AudioSource audioSource;
    private AudioClip currentMusic;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (IsDayTime())
        {
            PlayDayMusic();
        }
        else
        {
            PlayNightMusic();
        }
    }

    private void PlayDayMusic()
    {
        currentMusic = dayMusicTracks[Random.Range(0, dayMusicTracks.Length)];
        audioSource.clip = currentMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void PlayNightMusic()
    {
        currentMusic = nightMusicTracks[Random.Range(0, nightMusicTracks.Length)];
        audioSource.clip = currentMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void UpdateVolumeBasedOnDistance()
    {
        float distance = GetDistanceToSource();
        float volume = Mathf.Clamp(1 - distance / 20f, 0, 1);
        UpdateVolume(volume);
    }

    private void UpdateVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private float GetDistanceToSource()
    {
        return Vector3.Distance(player.position, transform.position);
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    private bool IsDayTime()
    {
        // Replace with actual day/night check logic.
        return Time.time % 24 < 12; // Example: Day time 0-12, Night time 12-24
    }
}
