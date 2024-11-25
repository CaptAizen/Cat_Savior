using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonstersPissed2 : MonoBehaviour
{
    bool SoundPLayed = false;
    CatSavedCounter counter;
    AudioSource Monster;
    // Start is called before the first frame update
    void Start()
    {
        Monster = GetComponent<AudioSource>();
        counter = GameObject.FindObjectOfType<CatSavedCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.Cats == 2 && SoundPLayed == false)
        {
            SoundPLayed = true;
            Monster.Play();
            Destroy(this, Monster.clip.length);
        }
    }
}
