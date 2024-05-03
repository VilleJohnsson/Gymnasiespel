using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageRadius = 1.5f;
    public float damageCooldown = 4f;

    private float lastDamageTime = -Mathf.Infinity;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time - lastDamageTime >= damageCooldown && collision.gameObject.CompareTag("Player"))
        {
            float distance = Vector2.Distance(transform.position, collision.transform.position);
            if (distance <= damageRadius)
            {
                Health playerHealth = collision.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                    lastDamageTime = Time.time;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
