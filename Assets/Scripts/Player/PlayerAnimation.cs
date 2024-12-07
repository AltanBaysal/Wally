using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    private Vector2 currentDirection;

    private void Update()
    {
        // Get input and calculate movement
        currentDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // Update animation based on movement
        UpdateAnimation(currentDirection);
    }

    public void UpdateAnimation(Vector2 direction)
    {
        // Set blend tree parameters
        float horizontal = Mathf.Clamp(direction.x, -0.5f, 0.5f);
        float vertical = Mathf.Clamp(direction.y, -0.5f, 0.5f);

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

    }
}
