using UnityEngine;

public class Playergravity : MonoBehaviour
{
    public float gravityStrength = 9.8f; // Strength of gravity
    Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Apply gravity by adjusting the Rigidbody2D's velocity in the y-axis
        rb.velocity += Vector2.down * gravityStrength * Time.fixedDeltaTime;
    }
}
