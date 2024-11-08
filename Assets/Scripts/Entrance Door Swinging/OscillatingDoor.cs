using System.Collections;
using UnityEngine;

public class OscillatingDoor : MonoBehaviour
{
    public float startAngle = 0f; // Starting angle of the door
    public float endAngle = 90f; // Ending angle of the door
    public float oscillationSpeed = 1f; // Speed of oscillation
    public float pauseDuration = 0.5f; // Duration of pause at each oscillation point
    public float randomVariationRange = 5f; // Range for random variation

    private bool increasing = true; // Direction of oscillation

    void Start()
    {
        StartCoroutine(OscillateDoor());
    }

    private IEnumerator OscillateDoor()
    {
        while (true)
        {
            float currentAngle = increasing ? startAngle : endAngle;
            float targetAngle = increasing ? endAngle : startAngle;

            // Add random variation to the target angle
            targetAngle += Random.Range(-randomVariationRange, randomVariationRange);

            while (Mathf.Abs(currentAngle - targetAngle) > 0.01f)
            {
                float step = oscillationSpeed * Time.deltaTime;
                currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, step);
                transform.rotation = Quaternion.Euler(0, currentAngle, 0); // Adjust the rotation of the current object
                yield return null;
            }

            yield return new WaitForSeconds(pauseDuration);
            increasing = !increasing;
        }
    }
}
