using System.Collections;
using UnityEngine;

public class StopOscillatingDoor : MonoBehaviour
{
    public GameObject[] doors; // Array of GameObjects with the OscillatingDoor script
    public float[] shutAngles; // Array of angles at which each door is considered shut
    public float closingSpeed = 2f; // Speed at which the doors close
    public AudioSource[] shutSoundSources; // Array of AudioSource components for the shut sound
    public bool DoorsClosed = false;

    private int currentSoundIndex = 0; // Index to track the current AudioSource
    private int doorsClosedCount = 0; // Track the number of closed doors

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            foreach (GameObject door in doors)
            {
                OscillatingDoor oscillatingDoor = door.GetComponent<OscillatingDoor>();
                if (oscillatingDoor != null)
                {
                    oscillatingDoor.StopAllCoroutines(); // Stop all coroutines in the OscillatingDoor script
                    oscillatingDoor.enabled = false; // Disable the OscillatingDoor script
                }
            }
            StartCoroutine(CloseDoors());
        }
    }

    private IEnumerator CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            int doorIndex = i;
            GameObject door = doors[doorIndex];
            float shutAngle = shutAngles[doorIndex];
            float currentAngle = door.transform.rotation.eulerAngles.y;

            StartCoroutine(CloseDoor(door, currentAngle, shutAngle));
        }

        yield return null; // Ensure the coroutine completes
    }

    private IEnumerator CloseDoor(GameObject door, float currentAngle, float shutAngle)
    {
        while (Mathf.Abs(currentAngle - shutAngle) > 0.01f)
        {
            float step = closingSpeed * Time.deltaTime;
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, shutAngle, step);
            door.transform.rotation = Quaternion.Euler(0, currentAngle, 0);
            yield return null;
        }

        door.transform.rotation = Quaternion.Euler(0, shutAngle, 0); // Ensure it ends exactly at the shut angle
        doorsClosedCount++;

        // Check if all doors are closed
        if (doorsClosedCount == doors.Length)
        {
            DoorsClosed = true;
            Debug.Log("All doors are closed. DoorsClosed set to true.");
            // Play the shut sound using the next available AudioSource
            if (shutSoundSources.Length > 0)
            {
                shutSoundSources[currentSoundIndex].Play();
                currentSoundIndex = (currentSoundIndex + 1) % shutSoundSources.Length;
            }
            // Deactivate this script's GameObject
            gameObject.SetActive(true);
        }
    }
}
