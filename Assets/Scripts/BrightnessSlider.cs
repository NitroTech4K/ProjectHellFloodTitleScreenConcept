using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GammaGainControl : MonoBehaviour
{
    public Slider gammaSlider; // Reference to the UI Slider
    public Button resetButton; // Reference to the Reset Button
    private Volume postProcessVolume; // The Post-Processing Volume
    private ColorAdjustments colorAdjustments;

    private const float defaultExposure = 0f; // Default Post Exposure value

    void Start()
    {
        // Find the PostProcessing Volume in the scene
        postProcessVolume = FindObjectOfType<Volume>();

        if (postProcessVolume == null)
        {
            Debug.LogError("No Volume found in the scene. Please ensure you have a Volume in your scene.");
            return;
        }

        // Check if ColorAdjustments exists in the Volume Profile
        if (postProcessVolume.profile != null)
        {
            if (postProcessVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
            {
                // Set the default value for Post Exposure (gamma) to 0
                colorAdjustments.postExposure.value = defaultExposure;

                // Set the initial value for the slider to match the default Post Exposure
                gammaSlider.value = colorAdjustments.postExposure.value;
            }
            else
            {
                Debug.LogError("ColorAdjustments not found in the Volume Profile. Please ensure Color Adjustments is added to your Volume Profile.");
            }
        }
        else
        {
            Debug.LogError("Volume Profile is missing in the Post-Processing Volume.");
        }

        // Add listener to the slider to adjust the gamma when the user interacts with it
        gammaSlider.onValueChanged.AddListener(OnGammaChanged);

        // Set slider range to be more visible (for example, -5 to 5)
        gammaSlider.minValue = -5f;
        gammaSlider.maxValue = 5f;
        gammaSlider.value = defaultExposure;  // Set the default value to 0 for initial position

        // Add listener to reset button to reset the value
        resetButton.onClick.AddListener(ResetExposure);
    }

    void OnGammaChanged(float value)
    {
        // Adjust the gamma gain using the post-exposure property of the Color Adjustments effect
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
        }
        else
        {
            Debug.LogError("ColorAdjustments component is not available.");
        }
    }

    void ResetExposure()
    {
        // Reset the Post Exposure to the default value (0)
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = defaultExposure;
            gammaSlider.value = defaultExposure;  // Reset the slider to 0 as well
        }
    }

    void OnDestroy()
    {
        // Clean up the event listener when the script is destroyed
        gammaSlider.onValueChanged.RemoveListener(OnGammaChanged);
        resetButton.onClick.RemoveListener(ResetExposure); // Remove reset listener
    }
}
