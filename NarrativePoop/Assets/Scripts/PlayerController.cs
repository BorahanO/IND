using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 1f; // Rate at which player accelerates
    public float maxSpeed = 5f; // Maximum speed of the player
    public float deceleration = 0.5f; // Rate at which player decelerates

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput).normalized;

        if (inputVector != Vector2.zero)
        {
            // Rotate towards movement direction
            float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Accelerate in the input direction
            rb.velocity += inputVector * acceleration * Time.deltaTime;

            // Clamp velocity to the maximum speed
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        else
        {
            // Decelerate when no input is given
            rb.velocity -= rb.velocity * deceleration * Time.deltaTime;
        }
    }
}
