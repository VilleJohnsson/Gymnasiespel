using UnityEngine;

public class EnemyWeight : MonoBehaviour
{
    public float weight = 1f; // Weight of the enemy
    public float gravityScale = 1f; // Gravity scale for the enemy

    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        // Get the Rigidbody2D component attached to the enemy
        rb = GetComponent<Rigidbody2D>();

        // Set the gravity scale for the enemy
        rb.gravityScale = gravityScale;
    }

    void FixedUpdate()
    {
        // Apply gravity to the enemy based on its weight and the gravity scale
        rb.AddForce(Vector2.down * weight * rb.gravityScale);
    }
}
