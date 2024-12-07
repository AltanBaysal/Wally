using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Vector3 targetPosition;

    public void Initialize(Vector3 target)
    {
        targetPosition = target;
    }

    private void Update()
    {
        // Move the bullet towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Destroy the bullet when it reaches the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
