using System.Collections;
using UnityEngine;

public class GateControllerRight : MonoBehaviour
{
    public float openSpeedRight = 2f; // Speed at which the gate opens
    public float oscillationSpeedRight = 1f; // Speed of oscillation
    public float pauseDurationRight = 0.5f; // Duration of pause at each oscillation point
    public bool isOpeningRight = false;
    public bool isOscillatingRight = false;
    public AudioSource gateAudioSource; // Reference to the AudioSource component for opening sound
    public AudioSource slamAudioSource; // Reference to the AudioSource component for slamming sound

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            Debug.Log("is player");
            if (!isOpeningRight && !isOscillatingRight)
            {
                StartCoroutine(OpenGateRight());
            }
        }
    }

    private IEnumerator OpenGateRight()
    {
        isOpeningRight = true;
        float targetAngle = 90f;
        float currentAngle = 0f;

        // Play the gate opening sound
        if (gateAudioSource != null)
        {
            gateAudioSource.Play();
        }

        // Open the gate
        while (currentAngle < targetAngle)
        {
            float step = Mathf.Lerp(0.1f, openSpeedRight, currentAngle / targetAngle) * Time.deltaTime;
            currentAngle += step;
            transform.rotation = Quaternion.Euler(0, currentAngle, 0); // Adjust the rotation of the current object

            // Adjust the volume inversely proportional to the speed
            if (gateAudioSource != null)
            {
                gateAudioSource.volume = Mathf.Lerp(1f, 0.1f, currentAngle / targetAngle);
            }

            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, targetAngle, 0); // Ensure it ends exactly at 90 degrees
        isOpeningRight = false;

        // Stop the gate opening sound
        if (gateAudioSource != null)
        {
            gateAudioSource.Stop();
        }

        // Play the slamming sound
        if (slamAudioSource != null)
        {
            slamAudioSource.Play();
        }

        // Start oscillation
        StartCoroutine(OscillateGateRight());
    }

    private IEnumerator OscillateGateRight()
    {
        isOscillatingRight = true;
        float minAngle = 82f;
        float maxAngle = 92f;
        float currentAngle = 90f;
        bool increasing = true;

        while (true)
        {
            float targetAngle = increasing ? maxAngle : minAngle;
            while (Mathf.Abs(currentAngle - targetAngle) > 0.01f)
            {
                float step = oscillationSpeedRight * Time.deltaTime;
                currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, step);
                transform.rotation = Quaternion.Euler(0, currentAngle, 0); // Adjust the rotation of the current object
                yield return null;
            }

            yield return new WaitForSeconds(pauseDurationRight);
            increasing = !increasing;
        }
    }
}
