using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float offsetY = 0.1f; // Offset for raycast origin (to avoid checking directly from feet)

    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get the layer mask for the Ground layer
        int groundLayer = LayerMask.NameToLayer("Ground");
        LayerMask groundLayerMask = 1 << groundLayer;

        // Raycast to detect the ground below the character
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * offsetY, Vector2.down, Mathf.Infinity, groundLayerMask);

        // If the raycast hits the ground, adjust the character's position
        if (hit.collider != null)
        {
            float distanceToGround = hit.distance;
            Vector2 velocity = rb.velocity;

            // Check if the character is falling (negative vertical velocity)
            if (velocity.y < 0)
            {
                // Adjust character's position to be slightly above the ground
                rb.position += new Vector2(0f, distanceToGround - offsetY);
            }
        }
    }
}
