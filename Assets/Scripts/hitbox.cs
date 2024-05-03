using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Transform attackPoint; // Reference to the attack point transform

    // Animation event method to enable the hitbox
    public void EnableHitbox()
    {
        if (attackPoint != null)
        {
            attackPoint.gameObject.SetActive(true); // Enable the attack point GameObject
        }
        else
        {
            Debug.LogError("Attack point not assigned!");
        }
    }

    // Animation event method to disable the hitbox
    public void DisableHitbox()
    {
        if (attackPoint != null)
        {
            attackPoint.gameObject.SetActive(false); // Disable the attack point GameObject
        }
        else
        {
            Debug.LogError("Attack point not assigned!");
        }
    }

    // Called when the character's attack collider overlaps with another collider (trigger)
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to an enemy
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(other.gameObject);
        }
    }
}
