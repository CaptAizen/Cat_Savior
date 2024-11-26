using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat1 : MonoBehaviour
{
    AudioSource HeartBeatSound;

    // Start is called before the first frame update
    void Start()
    {
        HeartBeatSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        HeartBeatSound.Play();
        HeartBeatSound.loop = true;
    }
}
