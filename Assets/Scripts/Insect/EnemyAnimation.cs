using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    private Vector2 movementDirection;

    private void Update()
    {
        // Get the movement direction from the EnemyBehaviorAI (based on movement towards target)
        EnemyBehaviorAI enemyBehavior = GetComponent<EnemyBehaviorAI>();
        if (enemyBehavior != null && enemyBehavior.currentTarget != null)
        {
            Vector3 directionToTarget = (enemyBehavior.currentTarget.transform.position - transform.position).normalized;
            movementDirection = new Vector2(directionToTarget.x, directionToTarget.y);
        }
        else
        {
            movementDirection = Vector2.zero;  // No movement if no target
        }

        // Update the animation based on movement direction
        UpdateAnimation(movementDirection);
    }

    public void UpdateAnimation(Vector2 direction)
    {
        // Ensure we pass normalized values to the animator for smooth transitions
        float horizontal = Mathf.Clamp(direction.x, -1f, 1f);
        float vertical = Mathf.Clamp(direction.y, -1f, 1f);

        // Set the animator parameters for blend tree
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
