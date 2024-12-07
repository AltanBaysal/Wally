using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public Transform centerPoint; // Center point of the "main circle"
    public float mainCircleRadius = 10f; // Radius of the "main circle"
    public float spawnAreaRadius = 30f; // Total spawn area radius
    public int enemiesPerNight = 5; // Number of enemies to spawn each night
    public float spawnCooldown = 1f; // Cooldown between enemy spawns

    [Header("Time Settings")]
    public float dayNightCycleLength = 60f; // Total length of the day-night cycle in seconds
    public float nightStart = 30f; // Fraction of the day-night cycle when night starts

    public float timer; // Tracks the current time in the day-night cycle
    public bool isNighttime = false; // Flag to track if it's night
    private bool isEnemySpawned = false; // Flag to prevent spawning during the day
    private float spawnTimer = 0f; // Timer for cooldown between spawns
    public int dayCount = 0;

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's nighttime
        float dayFraction = timer % dayNightCycleLength;
        isNighttime = dayFraction >= nightStart;

        if (!isNighttime)
        {
            isEnemySpawned = false;
            
        }
        else
        {
            if (!isEnemySpawned)
            {
                SpawnEnemies();
                isEnemySpawned = true;
                dayCount++;
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
        isEnemySpawned = true; // Mark that enemies have been spawned
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
}
