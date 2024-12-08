using TMPro;
using UnityEngine;
using UnityEngine.UI; // Add this for using Text

public class EnemySpawner : MonoBehaviour
{
    public GameObject bossSpawnPoint; // Enemy prefab to spawn
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public GameObject bossPrefab; // Caterpillar boss prefab
    public Transform centerPoint; // Center point of the "main circle"
    public float mainCircleRadius = 10f; // Radius of the "main circle"
    public float spawnAreaRadius = 30f; // Total spawn area radius
    public int enemiesPerNight = 5; // Number of enemies to spawn each night
    public float spawnCooldown = 1f; // Cooldown between enemy spawns
    [SerializeField] public AudioClip nightMusic; // Assign this in the inspector
    [SerializeField] public AudioClip dayMusic; // Assign this in the inspector
    [SerializeField] public AudioClip bossFightMusic; // Special boss fight music

    public AudioSource audioSource;

    [Header("Time Settings")]
    public float dayNightCycleLength = 60f; // Total length of the day-night cycle in seconds
    public float nightStart = 30f; // Fraction of the day-night cycle when night starts

    public GameObject nightIndicator; // Object to show during nighttime

    private float timer; // Tracks the current time in the day-night cycle
    private bool isNighttime = false; // Flag to track if it's night
    private bool isEnemySpawned = false; // Flag to prevent spawning during the day
    private float spawnTimer = 0f; // Timer for cooldown between spawns
    public int dayCount = 0;

    public TextMeshProUGUI dayCountText; // Reference to the Text component to display day count

    private void Start()
    {
        PlayDayMusic();
        UpdateDayCountText(); // Initial update of day count
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's nighttime
        float dayFraction = timer % dayNightCycleLength;
        isNighttime = dayFraction >= nightStart;

        if (!isNighttime)
        {
            if (isEnemySpawned)
            {
                isEnemySpawned = false;
                SetNightIndicatorVisible(false); // Hide the night indicator
                PlayDayMusic(); // Start playing day music
            }
        }
        else
        {
            if (!isEnemySpawned)
            {
                SetNightIndicatorVisible(true); // Show the night indicator
                if (dayCount == 5) // Check for Day 5 to spawn the boss
                {
                    SpawnBoss(); // Spawn the caterpillar boss
                }
                else
                {
                    SpawnEnemies(); // Spawn regular enemies
                }
                isEnemySpawned = true;
                dayCount++;
                UpdateDayCountText(); // Update the day count text
                PlayNightMusic(); // Start playing night music
            }
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerNight; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            if (spawnPosition != Vector3.zero)
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void SpawnBoss()
    {
        if (bossSpawnPoint.transform.position != Vector3.zero)
        {
            Instantiate(bossPrefab, bossSpawnPoint.transform.position, Quaternion.identity); // Spawn the caterpillar boss
            PlayBossFightMusic(); // Play the special boss fight music
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        for (int attempts = 0; attempts < 50; attempts++) // Try to find a valid position
        {
            // Randomly generate a position outside the main square area on both X and Y axes
            float randomX = Random.Range(centerPoint.position.x - spawnAreaRadius, centerPoint.position.x + spawnAreaRadius);
            float randomY = Random.Range(centerPoint.position.y - spawnAreaRadius, centerPoint.position.y + spawnAreaRadius);

            Vector3 randomPosition = new Vector3(randomX, randomY, centerPoint.position.z);

            // Ensure the position is outside the main square area
            if (Mathf.Abs(randomX - centerPoint.position.x) > mainCircleRadius && Mathf.Abs(randomY - centerPoint.position.z) > mainCircleRadius)
            {
                return randomPosition; // Valid position found outside the main square
            }
        }

        return Vector3.zero; // Failed to find a valid position
    }

    private void SetNightIndicatorVisible(bool isVisible)
    {
        if (nightIndicator != null)
        {
            nightIndicator.SetActive(isVisible);
        }
    }

    private void PlayNightMusic()
    {
        if (audioSource != null && nightMusic != null)
        {
            // Stop any currently playing music
            audioSource.Stop();
            // Play the night music and set it to loop
            audioSource.clip = nightMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void PlayDayMusic()
    {
        if (audioSource != null && dayMusic != null)
        {
            // Stop any currently playing music
            audioSource.Stop();
            // Play the day music and set it to loop
            audioSource.clip = dayMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void PlayBossFightMusic()
    {
        if (audioSource != null && bossFightMusic != null)
        {
            // Stop any currently playing music
            audioSource.Stop();
            // Play the boss fight music and set it to loop
            audioSource.clip = bossFightMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void UpdateDayCountText()
    {
        if (dayCountText != null)
        {
            dayCountText.text = "Gün: " + dayCount; // Update the text to display the current day
        }
    }
}
