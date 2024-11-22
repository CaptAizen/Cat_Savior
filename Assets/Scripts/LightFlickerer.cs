using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerer : MonoBehaviour
{
    Light myLight;
    CatSavedCounter counter;
    [Range(0f, 30f)]
    public float FirstDelay;
    [Range(0f, 30f)]
    public float SecondDelay;
    [Range(0f, 30f)]
    public float ThirdDelay;
    [Range(0f, 30f)]
    public float FourthDelay;
    [Range(0f, 30f)]
    public float FifthDelay;
    [Range(0f, 30f)]
    public float SixthDelay;
    bool IsBuzzing = false;
   
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        counter = GameObject.FindObjectOfType<CatSavedCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.Cats == 1 && !IsBuzzing)
        {
            IsBuzzing = true;
            StartCoroutine(Buzz());
        }
    }

    IEnumerator Buzz()
    {
        while (true)
        {
            // Dark for 3 seconds
            myLight.intensity = 0;
            yield return new WaitForSeconds(FirstDelay);

            // On for 1 second
            myLight.intensity = 5;
            yield return new WaitForSeconds(SecondDelay);

            // Off for 1 second
            myLight.intensity = 0;
            yield return new WaitForSeconds(ThirdDelay);

            // On for 3 seconds
            myLight.intensity = 5;
            yield return new WaitForSeconds(FourthDelay);
            // Off for 1 second
            myLight.intensity = 0;
            yield return new WaitForSeconds(FifthDelay);

            // On for 3 seconds
            myLight.intensity = 5;
            yield return new WaitForSeconds(SixthDelay);
        }
    }
}
