using System;
using UnityEngine;

public class PlantBehavior : MonoBehaviour
{
    public enum GrowthStage { Seed, Sprout, Mature }

    [SerializeField] private int health = 100;
    [SerializeField] private GrowthStage growthStage = GrowthStage.Seed;
    [SerializeField] private float growthTime = 5f;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private Vector3 position;
    [SerializeField] private SpriteRenderer plantSpriteRenderer;
    [SerializeField] private Sprite seedSprite;
    [SerializeField] private Sprite sproutSprite;
    [SerializeField] private Sprite matureSprite;

    private float growthTimer = 0f;

    void Start()
    {
        position = transform.position;
        StartGrowth();
        UpdateAppearance();
    }

    public void StartGrowth()
    {
        growthStage = GrowthStage.Seed;
        growthTimer = 0f;
    }

    public void Damage(int amount)
    {
        health -= amount;
        UpdateHealthBar();

        if (health <= 0)
        {
            Destroy(gameObject); // Destroys the GameObject when health is zero or less
        }
    }

    public void Harvest()
    {
        UpdateInventory();
        Destroy(gameObject);

    }

    void Update()
    {
        if (isAlive)
        {
            Console.WriteLine(Time.deltaTime);
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

        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        if (plantSpriteRenderer != null)
        {
            switch (growthStage)
            {
                case GrowthStage.Seed:
                    plantSpriteRenderer.sprite = seedSprite;
                    break;
                case GrowthStage.Sprout:
                    plantSpriteRenderer.sprite = sproutSprite;
                    break;
                case GrowthStage.Mature:
                    plantSpriteRenderer.sprite = matureSprite;
                    break;
            }
        }
    }

    private void UpdateHealthBar()
    {
        // Logic to update health bar UI
    }

    private void UpdateInventory()
    {
        //TODO kaynakları arttırma ekle
    }
}
