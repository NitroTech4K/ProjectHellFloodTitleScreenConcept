using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class ResolutionDropdown : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // Use TMP_Dropdown instead of Dropdown

    private Resolution[] resolutions;

    void Start()
    {
        // Get available resolutions from the system
        resolutions = Screen.resolutions;

        // Clear any existing options from the dropdown
        resolutionDropdown.ClearOptions();

        // Create a list to hold resolution strings
        List<string> options = new List<string>();

        // Populate the dropdown with resolution options
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Check if this is the current resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Add the resolution options to the dropdown
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
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
