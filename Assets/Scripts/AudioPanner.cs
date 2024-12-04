using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioPanController : MonoBehaviour
{
    public AudioSource audioSource;   // The audio source to control
    public Slider panSlider;          // UI Slider to control the pan (-1 = left, 0 = center, 1 = right)
    public Button resetButton;        // UI Button to reset the pan to center

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Set initial pan to center
        audioSource.panStereo = 0f;

        // Listen for slider value changes to adjust the pan
        if (panSlider != null)
        {
            panSlider.onValueChanged.AddListener(SetPan);
            panSlider.value = 0f; // Set slider default value to center
        }

        // Listen for reset button click to reset the pan
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetPan);
        }
    }

    // Function to set the stereo pan based on the slider value
    public void SetPan(float panValue)
    {
        audioSource.panStereo = panValue;
    }

    // Function to reset the pan to center
    public void ResetPan()
    {
        if (panSlider != null)
        {
            // Reset slider value to center
            panSlider.value = 0f;

            // Directly reset the audio source pan to center
            audioSource.panStereo = 0f;
        }
    }
}
