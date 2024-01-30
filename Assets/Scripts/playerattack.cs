using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float attackRange = 2f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;
    public GameObject attackHitbox; // Reference to the attack hitbox GameObject
    public Animator animator;

    private bool isAttacking = false;

    void Start()
    {
        if (attackHitbox == null)
        {
            Debug.LogError("Attack hitbox not assigned!");
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Disable the attack hitbox initially
        if (attackHitbox != null)
        {
            attackHitbox.SetActive(false);
        }
    }

    void Update()
    {
        // Check for attack input only if the player is not currently attacking
        if (!isAttacking && Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Trigger the attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Enable the attack hitbox when attacking
        if (attackHitbox != null)
        {
            attackHitbox.SetActive(true);

            // Perform attack logic
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                // Check if the collided object has a Health component
                Health enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    // Deal damage to the enemy
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
        }

        // Set a flag to prevent continuous attacks
        isAttacking = true;

        // Invoke a method to disable the hitbox after a delay (adjust as needed)
        Invoke("DisableHitbox", 0.5f);
    }

    void DisableHitbox()
    {
        // Disable the attack hitbox
        if (attackHitbox != null)
        {
            attackHitbox.SetActive(false);
        }

        // Reset the attacking flag after the hitbox is disabled
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the attack range in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
