using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;



public class MonstersPissed4 : MonoBehaviour
{
    bool SoundPLayed = false;
    CatSavedCounter counter;
    AudioSource Doorslide;
    public GameObject Doors;
    public float start;
    public float end;
    public float current = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Doorslide = GetComponent<AudioSource>();
        counter = GameObject.FindObjectOfType<CatSavedCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.Cats == 4 && SoundPLayed == false)
        {
            SoundPLayed = true;
            Doorslide.Play();
            Destroy(this, Doorslide.clip.length);
            StartCoroutine (DoorSliding());
        }
    }
    IEnumerator DoorSliding()
    {
        while (current < end)
        {
            transform.position = new Vector3(0, Mathf.Lerp(start, end, current), 0);
            current += 0.5f * Time.deltaTime;
            yield return null;  
        }
    }
}
