using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space;
    public float attackRange = 2f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;
    public Transform attackPoint; // Reference to the attack point transform
    public Animator animator;

    private bool isAttacking = false;

    void Start()
    {
        if (attackPoint == null)
        {
            Debug.LogError("Attack point not assigned!");
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
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

    // Perform attack logic
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

    foreach (Collider2D enemy in hitEnemies)
    {
        // Check if the collided object has a Health component
        Health enemyHealth = enemy.GetComponent<Health>();
        if (enemyHealth != null)
        {
            // Deal damage to the enemy
            enemyHealth.TakeDamage(attackDamage);

            // Log a debug message indicating that the enemy was hit
            Debug.Log("We hit " + enemy.name);
        }
    }

    // Set a flag to prevent continuous attacks
    isAttacking = true;

    // Invoke a method to reset the attacking flag after a delay (adjust as needed)
    Invoke("ResetAttackFlag", 0.5f);
}

    void ResetAttackFlag()
    {
        // Reset the attacking flag
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the attack range in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
