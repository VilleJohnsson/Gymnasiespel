using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Animation event method to enable the hitbox
    public void EnableHitbox()
    {
        gameObject.SetActive(true); // Enable the punch collider
    }

    // Animation event method to disable the hitbox
    public void DisableHitbox()
    {
        gameObject.SetActive(false); // Disable the punch collider
    }

    // Called when the character's punch collider overlaps with another collider (trigger)
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
