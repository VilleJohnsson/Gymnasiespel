using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public float deathYThreshold = -10f; // Y-coordinate threshold for death

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.maxHealth); // Inflict fatal damage
            }
        }
    }
}
