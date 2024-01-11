using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider; // Reference to the UI Slider for health visualization

    void Start()
    {
        currentHealth = maxHealth;

        // Find and link the Slider UI in the scene
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health between 0 and maxHealth

        // Update UI Slider
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); // Call function for death or destroy the object
        }
    }

    void Die()
    {
        // Implement logic for death: e.g., play death animation, respawn, etc.
        // For example:
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject); // Destroy the object
    }
}
