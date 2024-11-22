using UnityEngine;
using UnityEngine.Audio;

public class IndoorOutdoorAudioControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string outdoorVolumeParam = "OutdoorVolume"; // Correct parameter name
    public string indoorVolumeParam = "IndoorVolume"; // Correct parameter name
    public float transitionDuration = 1.0f;
    public StopOscillatingDoor doorCloser; // Reference to StopOscillatingDoor script

    [SerializeField] private bool isIndoor = false; // Expose isIndoor to the Inspector
    private bool shouldTransition = false;
    private float transitionTime = 0.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldTransition = true;
        }
    }

    void Update()
    {
        if (shouldTransition && doorCloser != null && doorCloser.DoorsClosed)
        {
            isIndoor = true;
            transitionTime = 0.0f;
            shouldTransition = false; // Ensure the transition only starts once
        }

        if (isIndoor)
        {
            transitionTime += Time.deltaTime;
            float t = Mathf.Clamp01(transitionTime / transitionDuration);
            float outdoorVolume = Mathf.Lerp(0, -20, t);
            float indoorVolume = Mathf.Lerp(-80, -5, t);

            bool outdoorSet = audioMixer.SetFloat(outdoorVolumeParam, outdoorVolume);
            bool indoorSet = audioMixer.SetFloat(indoorVolumeParam, indoorVolume);


            // Ensure parameters exist in the Audio Mixer
            float outdoorCheck, indoorCheck;
            bool outdoorExists = audioMixer.GetFloat(outdoorVolumeParam, out outdoorCheck);
            bool indoorExists = audioMixer.GetFloat(indoorVolumeParam, out indoorCheck);


            // Stop updating after the transition is complete
            if (transitionTime >= transitionDuration)
            {
                isIndoor = false;
            }
        }
        else
        {
        }
    }
}
