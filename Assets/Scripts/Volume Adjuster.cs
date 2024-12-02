using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    // Reference to the AudioSource component
    public AudioSource audioSource;

    // Reference to the UI Slider
    public Slider volumeSlider;

    void Start()
    {
        // Check if the references are set in the inspector
        if (audioSource != null && volumeSlider != null)
        {
            // Initialize slider value to match the current audioSource volume
            volumeSlider.value = audioSource.volume;

            // Add a listener to the slider to call the OnVolumeChange method when the value changes
            volumeSlider.onValueChanged.AddListener(OnVolumeChange);
        }
    }

    // This method is called when the slider's value changes
    public void OnVolumeChange(float volume)
    {
        audioSource.volume = volume;
    }
}
