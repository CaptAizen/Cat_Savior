using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPopper : MonoBehaviour
{
    CatSavedCounter catSavedCounter;
    Light myLight;
    public float Delay;
    public float BrightnessMaximum = 30;
    public float BrightnessGrowthRate = 25;
    public bool bulbpopped = false;
    AudioSource myAudioSource;
    public float DelayRandomRange = 1.7f;
    
    // Start is called before the first frame update
    void Start()
    {
        catSavedCounter = GameObject.FindObjectOfType<CatSavedCounter>();

        myLight = GetComponent<Light>();
        myLight.enabled = true;
        myLight.intensity = 5f;

        myAudioSource = GetComponent<AudioSource>();
        Delay += UnityEngine.Random.Range(0, DelayRandomRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (catSavedCounter.Cats == 1 && !bulbpopped)
        {
            StartCoroutine(LightFlickerer());
            bulbpopped = true;
        }
    }

    IEnumerator LightFlickerer()
    {
        while (myLight.intensity < BrightnessMaximum)
        {
            myLight.intensity += BrightnessGrowthRate * Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(Delay);
        myAudioSource.PlayOneShot(myAudioSource.clip);
        Destroy(myLight);
        yield return new WaitForSeconds(myAudioSource.clip.length);
        this.enabled = false;
    }
}
