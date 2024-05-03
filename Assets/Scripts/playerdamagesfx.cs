using UnityEngine;

public class PlayerDamageSFX : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDamageSFX()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
