using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    AudioSource HeartBeatSound;
    bool SoundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        HeartBeatSound = GetComponent<AudioSource>();
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!HeartBeatSound.isPlaying && SoundPlayed == false)
            {
                HeartBeatSound.Play();
                HeartBeatSound.loop = true;
                SoundPlayed = true;
            }
        }
    }
}
