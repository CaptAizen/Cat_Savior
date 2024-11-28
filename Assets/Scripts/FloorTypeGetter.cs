using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioClip[] woodFootsteps;
    public AudioClip[] carpetFootsteps;
    public AudioClip[] concreteFootsteps;
    public AudioClip[] gravelFootsteps;
    public AudioClip[] grassFootsteps;
    public AudioSource footstepSource;

    private Dictionary<string, int> layerPriority = new Dictionary<string, int>()
    {
        { "Concrete", 4 },
        { "Water", 3 },
        { "Gravel", 2 },
        { "Carpet", 1 },
        { "Default", 0 } // Default (Grass) has the lowest priority
    };

    private Vector3 lastFootstepPosition;
    public float footstepDistanceThreshold = 0.5f;

    void Start()
    {
        lastFootstepPosition = transform.position;
    }

    void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastFootstepPosition);
        if (distanceMoved >= footstepDistanceThreshold)
        {
            CheckAndPlayFootstepSound();
            lastFootstepPosition = transform.position;
        }
    }

    void CheckAndPlayFootstepSound()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation);
        string highestPriorityLayer = GetHighestPriorityLayer(hitColliders);
        PlayFootstepSound(highestPriorityLayer);
    }

    string GetHighestPriorityLayer(Collider[] colliders)
    {
        List<string> detectedLayers = new List<string>();

        foreach (Collider collider in colliders)
        {
            string layerName = LayerMask.LayerToName(collider.gameObject.layer);
            detectedLayers.Add(layerName);
        }

        detectedLayers.Sort((a, b) => layerPriority[b].CompareTo(layerPriority[a]));
        return detectedLayers.Count > 0 ? detectedLayers[0] : "Default";
    }

    void PlayFootstepSound(string layer)
    {
        AudioClip[] selectedClips = null;

        switch (layer)
        {
            case "Concrete":
                selectedClips = concreteFootsteps;
                break;
            case "Water":
                selectedClips = woodFootsteps;
                break;
            case "Carpet":
                selectedClips = carpetFootsteps;
                break;
            case "Gravel":
                selectedClips = gravelFootsteps;
                break;
            case "Default": // Grass
                selectedClips = grassFootsteps;
                break;
            default:
                selectedClips = grassFootsteps;
                break;
        }

        if (selectedClips != null && selectedClips.Length > 0)
        {
            footstepSource.clip = selectedClips[UnityEngine.Random.Range(0, selectedClips.Length)];
            footstepSource.Play();
        }
    }
}
