using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}