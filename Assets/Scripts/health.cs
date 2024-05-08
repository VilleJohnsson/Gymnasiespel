using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; 
    private int currentHealth; 
    public AudioSource damageAudioSource; 
    public AudioSource deathAudioSource; 
    public Animator animator;

    public delegate void HealthChangeDelegate(int currentHealth, int maxHealth);
    public static event HealthChangeDelegate OnHealthChanged;
    public delegate void DeathDelegate();
    public static event DeathDelegate OnDeath;
    public delegate void PlayerDeathDelegate();
    public static event PlayerDeathDelegate OnPlayerDeath; 

    void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthBar(); 
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; 

        if (animator != null)
        {
            animator.SetTrigger("TakeDamage");
        }

        if (damageAudioSource != null)
        {
            damageAudioSource.Play();
        }

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0; 
            Die(); 
        }

        Debug.Log("Player took " + damageAmount + " damage. Current Health: " + currentHealth);
    }

    void UpdateHealthBar()
    {
        // Your health bar update logic here
    }

    public void Die()
    {
        if (deathAudioSource != null)
        {
            deathAudioSource.Play(); // Play the death sound effect
        }

        Debug.Log("Player has died.");

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        OnDeath?.Invoke();
        OnPlayerDeath?.Invoke();

        StartCoroutine(RestartAfterDelay(2f)); // Restart after 2 seconds
    }

    IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Restart logic goes here
        Debug.Log("Restarting...");
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth; 
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        UpdateHealthBar();
    }
}
