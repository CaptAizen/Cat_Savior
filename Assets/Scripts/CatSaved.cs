using UnityEngine;

public class CatSaved : MonoBehaviour
{
    bool soundplayed = false;
    public AudioSource CatMeow;
    private CatSavedCounter catSavedCounter; // Reference to the CatSavedCounter script

    private void Start()
    {
        // Find the player and get the CatSavedCounter script
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            catSavedCounter = player.GetComponent<CatSavedCounter>();
            if (catSavedCounter == null)
            {
            }
        }
        else
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            // Get the AudioSource from the current gameObject
            CatMeow = GetComponent<AudioSource>();
            catSavedCounter.Cats += 1;

            // Debug to ensure we have a valid AudioSource
            if (CatMeow == null)
            {
            }

            // Play the meow sound
            if (CatMeow.clip != null && !soundplayed)
            {
                soundplayed = true;
                CatMeow.Play();
                // Debug to ensure the sound is playing

                GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                
                // Destroy the cat after the sound finishes playing
                Destroy(gameObject, CatMeow.clip.length);
            }
            else
            {
                // Debug if no audio clip is assigned
                Destroy(gameObject);
            }

            // Increase the number of cats saved
            if (catSavedCounter != null)
            {
                
                Debug.Log("Cats saved: " + catSavedCounter.Cats);
            }
        }
    }
}
