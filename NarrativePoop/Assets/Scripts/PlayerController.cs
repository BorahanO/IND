using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] public float maxSpeed;
    [SerializeField] float deceleration;

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
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

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
