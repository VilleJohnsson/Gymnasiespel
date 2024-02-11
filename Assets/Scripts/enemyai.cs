using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed at which the enemy moves
    public LayerMask groundLayer; // Layer mask for detecting ground

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movementDirection; // Direction of movement for the enemy
    private bool isFacingRight = false; // Flag to track the direction the enemy is facing

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = false; // Set initial facing direction to left
    }

    void Update()
    {
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
    }

    void FixedUpdate()
    {
        // Move the enemy in the calculated direction
        rb.velocity = movementDirection * moveSpeed;
    }

  void FlipCharacter()
{
    // Set the facing direction based on the movement direction
    isFacingRight = movementDirection.x >= 0;

    // Flip the character's scale along the X-axis
    Vector3 newScale = transform.localScale;
    newScale.x = isFacingRight ? Mathf.Abs(newScale.x) : -Mathf.Abs(newScale.x);
    transform.localScale = newScale;
}


}
