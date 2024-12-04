using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionDropdown : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // Use TMP_Dropdown

    private List<Resolution> filteredResolutions;
    private float currentAspectRatio;

    void Start()
    {
        // Get the current screen aspect ratio
        currentAspectRatio = (float)Screen.width / Screen.height;

        // Get available resolutions and filter by aspect ratio
        Resolution[] allResolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        foreach (Resolution res in allResolutions)
        {
            float aspectRatio = (float)res.width / res.height;

            // Allow some tolerance to account for floating point precision
            if (Mathf.Abs(aspectRatio - currentAspectRatio) < 0.01f)
            {
                bool resolutionExists = filteredResolutions.Exists(r => r.width == res.width && r.height == res.height);
                if (!resolutionExists)
                {
                    filteredResolutions.Add(res);
                }
            }
        }

        // Clear any existing options from the dropdown
        resolutionDropdown.ClearOptions();

        // Create a list to hold resolution strings
        List<string> options = new List<string>();

        // Populate the dropdown with filtered resolution options
        int currentResolutionIndex = 0;
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string option = filteredResolutions[i].width + " x " + filteredResolutions[i].height;
            options.Add(option);

            // Check if this is the current resolution
            if (filteredResolutions[i].width == Screen.currentResolution.width &&
                filteredResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Add the filtered resolution options to the dropdown
        resolutionDropdown.AddOptions(options);

        // Set the current resolution as selected
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Add listener for when the dropdown value changes
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });
    }

    // Method to set the resolution based on dropdown selection
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
