using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public KeyCode attackKey = KeyCode.Space; // Attack key
    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    public int damageAmount = 20; // Amount of damage dealt to enemies

    public AudioSource attackAudioSource; // Reference to the AudioSource component for attack sound

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetKeyDown(attackKey)) // Check if attack key is pressed
            {
                Attack();
            }
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack"); // Trigger attack animation

        // Play attack sound effect if AudioSource is assigned
        if (attackAudioSource != null)
        {
            attackAudioSource.Play();
        }

        Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);

        for (int i = 0; i < damage.Length; i++)
        {
            EnemyHealth enemyHealth = damage[i].GetComponent<EnemyHealth>(); // Get enemy health component
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount); // Deal damage to enemy
            }
        }

        attackTime = startTimeAttack; // Reset attack cooldown
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
