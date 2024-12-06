
using UnityEngine;

public class PlantBehavior : MonoBehaviour
{
    public enum GrowthStage { Seed, Sprout, Mature }

    [SerializeField] private int health = 100;
    [SerializeField] private GrowthStage growthStage = GrowthStage.Seed;
    [SerializeField] private float growthTime = 5f;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private Vector3 position;

    private float growthTimer = 0f;

    void Start()
    {
        position = transform.position;
        StartGrowth();
    }

    public void StartGrowth()
    {
        growthStage = GrowthStage.Seed;
        growthTimer = 0f;
    }

    public void Damage(int amount)
    {
        if (isAlive)
        {
            health -= amount;
            PlayDamageAnimation();
            UpdateHealthBar();
            if (health <= 0)
            {
                isAlive = false;
            }
        }
    }

    public void Harvest()
    {
        if (isAlive)
        {
            UpdateInventory();
            TriggerHarvestAnimation();
        }
    }

    void Update()
    {
        if (isAlive)
        {
            growthTimer += Time.deltaTime;
            CheckGrowthProgress();
        }
    }

    private void CheckGrowthProgress()
    {
        if (growthTimer >= growthTime)
        {
            growthTimer = 0f;
            ProgressGrowthStage();
        }
    }

    private void ProgressGrowthStage()
    {
        if (growthStage == GrowthStage.Seed) 
            growthStage = GrowthStage.Sprout;
        else if (growthStage == GrowthStage.Sprout) 
            growthStage = GrowthStage.Mature;
    }

    private void PlayDamageAnimation()
    {
        // Trigger damage animation logic
    }

    private void UpdateHealthBar()
    {
        // Logic to update health bar UI
    }

    private void UpdateInventory()
    {
        // Logic to update resource inventory
    }

    private void TriggerHarvestAnimation()
    {
        // Trigger harvest animation logic
    }
}
