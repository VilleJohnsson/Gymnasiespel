using UnityEngine;

public class WeightController : MonoBehaviour
{
    public float weightMultiplier = 1.0f; // Multiplier to adjust the weight of the object
    Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ApplyWeight();
    }

    // Method to apply weight changes
    void ApplyWeight()
    {
        rb.gravityScale = weightMultiplier; // Set the gravity scale based on the weight multiplier
    }

    // Function to update the weight multiplier (for external changes)
    public void UpdateWeight(float newWeightMultiplier)
    {
        weightMultiplier = newWeightMultiplier;
        ApplyWeight();
    }
}
