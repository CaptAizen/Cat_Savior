using System.Collections;
using UnityEngine;

public class MonstersInTheWoodsTrigger : MonoBehaviour
{
    public GameObject[] monsterSoundObjects; // Array of GameObjects with AudioSource components
    public float minDelay = 0.1f; // Minimum delay between sounds
    public float maxDelay = 1f; // Maximum delay between sounds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            StartCoroutine(PlayMonsterSounds());
        }
    }

    private IEnumerator PlayMonsterSounds()
    {
        foreach (GameObject monsterSoundObject in monsterSoundObjects)
        {
            AudioSource audioSource = monsterSoundObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
                float delay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
