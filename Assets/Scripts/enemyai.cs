using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed at which the enemy moves
    public LayerMask groundLayer; // Layer mask for detecting ground
    public float detectionRadius = 5f; // Detection radius for detecting the player

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Animator animator; // Reference to the Animator component
    private Vector2 movementDirection; // Direction of movement for the enemy
    private bool isFacingRight = false; // Flag to track the direction the enemy is facing
    private bool playerDetected = false; // Flag to track if the player is detected

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
        isFacingRight = false; // Set initial facing direction to left
    }

    void Update()
    {
        // Check if the player is within detection radius
        if (!playerDetected && Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            playerDetected = true;
        }

        // If the player is not detected, return
        if (!playerDetected)
        {
            return;
        }

        // Calculate direction towards the player
        movementDirection = (player.position - transform.position).normalized;
        // Ignore vertical movement
        movementDirection.y = 0f;

        // Check for obstacles (ground) in the movement direction
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movementDirection, Mathf.Infinity, groundLayer);

        if (hit.collider != null)
        {
            // Calculate the perpendicular direction
            Vector2 perpendicularDirection = Vector2.Perpendicular(hit.normal).normalized;

            // Calculate the new movement direction
            movementDirection = (movementDirection + perpendicularDirection * 0.5f).normalized;
        }

        // Flip the enemy sprite if changing direction
        if ((movementDirection.x > 0 && !isFacingRight) || (movementDirection.x < 0 && isFacingRight))
        {
            FlipCharacter();
        }

        // Set the "Speed" parameter in the Animator based on the movement direction
        animator.SetFloat("Speed", Mathf.Abs(movementDirection.x));
    }

    void FixedUpdate()
    {
        // If the player is not detected, return
        if (!playerDetected)
        {
            return;
        }

        // Move the enemy in the calculated direction
        rb.velocity = movementDirection * moveSpeed;
    }

    void OnDrawGizmosSelected()
    {
        // Set Gizmos color
        Gizmos.color = Color.red;

        // Draw a wire sphere to represent the detection range
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    
    void FlipCharacter()
    {
        // Determine if the character should face right based on the movement direction
        bool shouldFaceRight = movementDirection.x >= 0;

        // If the character's facing direction is opposite to the intended direction, flip it
        if (isFacingRight != shouldFaceRight)
        {
            // Flip the facing direction
            isFacingRight = shouldFaceRight;

            // Get the current scale
            Vector3 newScale = transform.localScale;

            // Flip the character's scale along the X-axis
            newScale.x *= -1;

            // Apply the new scale
            transform.localScale = newScale;
        }
    }
}
