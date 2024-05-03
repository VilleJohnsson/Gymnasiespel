using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage; // Reference to the Image component
    public Sprite[] healthSprites; // Array of sprite images representing different health levels

    private void Start()
    {
        // Get the Image component if not assigned
        if (healthBarImage == null)
        {
            healthBarImage = GetComponent<Image>();
        }

        // Subscribe to the OnHealthChanged event
        Health.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnHealthChanged event to prevent memory leaks
        Health.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        // Calculate the health percentage
        float healthPercentage = (float)currentHealth / maxHealth;

        // Determine the index of the sprite image based on the health percentage
        int spriteIndex = Mathf.Clamp(Mathf.FloorToInt(healthPercentage * healthSprites.Length), 0, healthSprites.Length - 1);

        // Update the health bar's sprite image
        if (healthSprites.Length > 0)
        {
            healthBarImage.sprite = healthSprites[spriteIndex];
        }
    }
}
