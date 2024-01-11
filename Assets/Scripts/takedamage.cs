using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 20; // Amount of damage this object deals

    void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }
}
