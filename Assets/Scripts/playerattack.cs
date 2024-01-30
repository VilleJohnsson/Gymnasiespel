using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float attackRange = 2f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;
    public Collider attackHitbox;  // Reference to the attack hitbox Collider

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (attackHitbox == null)
        {
            Debug.LogError("Attack hitbox not assigned!");
        }

        // Disable the attack hitbox initially
        if (attackHitbox != null)
        {
            attackHitbox.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
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
            attackHitbox.enabled = true;

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
    }

    void DisableHitbox()
    {
        // Disable the attack hitbox when not attacking
        if (attackHitbox != null)
        {
            attackHitbox.enabled = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the attack range in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
