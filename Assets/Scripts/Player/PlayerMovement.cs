
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private bool isMoving = false;
    private Vector2 currentDirection;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        ChangeAnimationState();
    }

    private void Move()
    {
        currentDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        isMoving = currentDirection.magnitude > 0;

        if (isMoving)
        {
            transform.Translate(currentDirection * speed * Time.deltaTime);
        }
    }

    private void ChangeDirection(Vector2 newDirection)
    {
        currentDirection = newDirection.normalized;
        Move();
    }

    private void ChangeAnimationState()
    {
        if (animator != null)
        {
            animator.SetBool("isMoving", isMoving);
            animator.SetFloat("moveX", currentDirection.x);
            animator.SetFloat("moveY", currentDirection.y);
        }
    }
}
