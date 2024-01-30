using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public LayerMask playerLayer;

    private Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }

        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found!");
        }
    }

    void Update()
    {
        if (player != null && navMeshAgent != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Check if the player is within detection range
            if (distanceToPlayer <= detectionRange)
            {
                // Chase the player
                ChasePlayer();
            }
            else
            {
                // Stop chasing and return to the starting position or perform other idle behavior
                StopChasing();
            }

            // Check if the player is within attack range
            if (distanceToPlayer <= attackRange)
            {
                // Attack the player (you can implement your attack logic here)
                AttackPlayer();
            }
        }
    }

    void ChasePlayer()
    {
        navMeshAgent.SetDestination(player.position);
    }

    void StopChasing()
    {
        navMeshAgent.ResetPath();
    }

    void AttackPlayer()
    {
        // Implement your attack logic here
        Debug.Log("Attacking Player!");
    }
}
