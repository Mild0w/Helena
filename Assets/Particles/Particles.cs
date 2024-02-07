using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public ParticleSystem particleSystemPrefab;
    public float particleLifetime = 3.0f;
    public AudioClip collisionSound; // Add the audio clip in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not found, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NotHolger"))
        {
            // Play collision sound
            PlayCollisionSound();

            // Instantiate and play particle system
            ParticleSystem particles = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

            // Access the Main module to set the particle lifetime
            var mainModule = particles.main;
            mainModule.startLifetime = particleLifetime;

            particles.Play();

            // Stop the particle system after the specified lifetime
            StartCoroutine(StopParticlesAfterLifetime(particles, particleLifetime));
        }
    }

    void PlayCollisionSound()
    {
        if (audioSource && collisionSound)
        {
            audioSource.clip = collisionSound;
            audioSource.Play();
        }
    }

    IEnumerator StopParticlesAfterLifetime(ParticleSystem particles, float lifetime)
    {
        yield return new WaitForSeconds(lifetime);

        // Stop the particle system
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Your update code here
    }
}


