using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class trigger : MonoBehaviour
{
    public AudioClip clip;


    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0));
        Debug.Log("Collider is functioning");
    }

    private void Start()
    {
        

    }

    private void Update()
    {
     
    }
}
