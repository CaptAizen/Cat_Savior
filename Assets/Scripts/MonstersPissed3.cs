using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonstersPissed3 : MonoBehaviour
{
    bool SoundPLayed = false;
    CatSavedCounter counter;
    AudioSource Monster;
    public GameObject Monsters;
    public AudioSource Heartbeat;
    // Start is called before the first frame update
    void Start()
    {
        Monster = GetComponent<AudioSource>();
        counter = GameObject.FindObjectOfType<CatSavedCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.Cats == 3 && SoundPLayed == false)
        {
            Heartbeat.pitch = 1.5f;
            Monster.Play();
            Destroy(this, Monster.clip.length);
            Monsters.SetActive(true);
            SoundPLayed = true;
        }
    }
}
