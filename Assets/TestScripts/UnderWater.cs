using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class UnderWater : MonoBehaviour
{
    public float underwaterDepth = 1.8f; // Adjust this value to set the underwater depth
    public PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;

    private void Start()
    {
        if (!postProcessVolume)
        {
            Debug.LogError("Post process volume is not assigned!");
            enabled = false;
            return;
        }

        postProcessVolume.profile.TryGetSettings(out colorGrading);
        if (colorGrading != null)
        {
            colorGrading.enabled.Override(true);
        }
    }

    private void Update()
    {
        // Check if the object's position is below the specified underwater depth
        if (transform.position.y < underwaterDepth)
        {
            // Apply color grading settings to darken the scene
            if (colorGrading != null)
            {
                // Adjust color grading settings for underwater effect
                // For example, decrease gamma, contrast, or exposure
                colorGrading.gamma.Override(new Color(0.5f, 0.5f, 0.5f)); // Example value
                colorGrading.contrast.Override(1.2f); // Example value
                colorGrading.postExposure.Override(0.5f); // Example value
            }
        }
        else
        {
            // Reset color grading settings when above water
            if (colorGrading != null)
            {
                colorGrading.gamma.Override(new Color(1f, 1f, 1f)); // Reset to default
                colorGrading.contrast.Override(1f); // Reset to default
                colorGrading.postExposure.Override(0f); // Reset to default
            }
        }
    }
}
