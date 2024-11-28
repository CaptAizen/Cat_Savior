using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class MonstersPissed4 : MonoBehaviour
{
    bool SoundPlayed = false;
    CatSavedCounter counter;
    AudioSource Doorslide;
    public GameObject Doors;
    public float start;
    public float end;
    public float current = 0f;
    public float slideDuration = 2f; // Duration for the door slide

    // Start is called before the first frame update
    void Start()
    {
        Doorslide = GetComponent<AudioSource>();
        counter = GameObject.FindObjectOfType<CatSavedCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.Cats == 4 && SoundPlayed == false)
        {
            SoundPlayed = true;
            Doorslide.Play();
            Destroy(this, Doorslide.clip.length);
            StartCoroutine(DoorSliding());
        }
    }

    IEnumerator DoorSliding()
    {
        float initialPosition = transform.position.y;
        float targetPosition = initialPosition + (end - start);

        while (current < slideDuration)
        {
            current += Time.deltaTime;
            float progress = Mathf.Clamp01(current / slideDuration);
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(initialPosition, targetPosition, progress), transform.position.z);
            yield return null;
        }
    }
}
