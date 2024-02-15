using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the character moves horizontally
    public float jumpForce = 10f; // Force applied when jumping
    public Animator animator; // Reference to the Animator component

    Rigidbody2D rb; // Reference to the Rigidbody2D component
    bool isFacingRight = true; // Flag to track the character's facing direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Horizontal Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        // Flip the character based on movement direction
        FlipCharacter(moveHorizontal);

        // Set the 'Speed' parameter in the Animator based on movement
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        // Trigger the running animation only when A or D keys are pressed
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            // Additional logic to handle running, if needed
            // For example, you can trigger additional effects or actions here
        }
        else
        {
            // Set 'Speed' to 0 when no movement keys are pressed
            animator.SetFloat("Speed", 0f);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.y, jumpForce);

            // Trigger the 'Jump' animation
            animator.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
    }

    void FlipCharacter(float horizontal)
    {
        // Flip the character if moving in the opposite direction
        if ((horizontal > 0 && !isFacingRight) || (horizontal < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;

            // Flip the character's scale along the X-axis
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}
