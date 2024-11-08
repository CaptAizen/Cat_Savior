using UnityEngine;

public class ThunderSound : MonoBehaviour
{
    public AudioClip[] thunderClips; // Array of thunder sound clips
    private ParticleSystem particleSystem;
    private int previousParticleCount;

    // Range for random volume and pitch
    public float minVolume = 0.8f;
    public float maxVolume = 1.2f;
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        previousParticleCount = 0;
    }

    void Update()
    {
        int currentParticleCount = particleSystem.particleCount;
        if (currentParticleCount > previousParticleCount)
        {
            PlayThunderSound();
        }
        previousParticleCount = currentParticleCount;
    }

    void PlayThunderSound()
    {
        if (thunderClips.Length > 0)
        {
            // Select a random thunder clip
            AudioClip thunderClip = thunderClips[Random.Range(0, thunderClips.Length)];

            // Create a temporary AudioSource to play the sound
            AudioSource tempAudioSource = gameObject.AddComponent<AudioSource>();
            tempAudioSource.volume = Random.Range(minVolume, maxVolume);
            tempAudioSource.pitch = Random.Range(minPitch, maxPitch);
            tempAudioSource.PlayOneShot(thunderClip);

            // Destroy the temporary AudioSource after the clip has finished playing
            Destroy(tempAudioSource, thunderClip.length);
        }
    }
}
