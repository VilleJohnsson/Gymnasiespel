using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the character moves horizontally
    public float jumpForce = 10f; // Force applied when jumping
    bool isGrounded; // Flag to check if the character is grounded

    Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        // Prevent vertical movement (up and down) using W and S buttons
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            movement.y = 0;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            rb.velocity = new Vector2(rb.velocity.y, jumpForce);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
