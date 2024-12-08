using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI; // For Slider

public class EnemyController : MonoBehaviour, HealthManager
{
    [SerializeField] private float health = 100;
    [SerializeField] public float maxhealth = 100;
    [SerializeField] public AudioClip deathSound; // Assign this in the inspector
    [SerializeField] public AudioClip damageSound; // Assign this in the inspector
    public AudioSource audioSource;

    [SerializeField] private Slider healthSlider; // Reference to the Slider

    private void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxhealth; // Set the maximum value of the slider to 100
            healthSlider.value = health; // Initialize the slider with current health (100)
        }
    }

    public void TakeDamage(float amount)
    {
        PlayTakeDamageSound();
        health -= amount;
        if (health < 0) health = 0; // Prevent health from going below 0

        UpdateHealthSlider();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayDeathSound();
        Destroy(gameObject); // Destroy the enemy object when dead
    }

    private void PlayDeathSound()
    {
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
    }

    private void PlayTakeDamageSound()
    {
        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = health; // Update slider with the actual health value
        }
    }
}
