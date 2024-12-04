using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public Toggle fullscreenToggle; // Reference to the UI toggle

    void Start()
    {
        // Set the toggle to default to "on" (fullscreen)
        fullscreenToggle.isOn = true;

        // Apply initial fullscreen setting
        Screen.fullScreen = fullscreenToggle.isOn;

        // Add a listener to the toggle to call the OnToggleValueChanged method
        fullscreenToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Method called when the toggle value changes
    void OnToggleValueChanged(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void OnDestroy()
    {
        // Remove the listener when the object is destroyed
        fullscreenToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }
}
