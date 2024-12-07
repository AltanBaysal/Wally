
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private bool isMoving = false;
    private Vector2 currentDirection;


    private void Update()
    {
        Move();
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
}
