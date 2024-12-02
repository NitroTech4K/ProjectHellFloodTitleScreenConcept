using UnityEngine;
using TMPro;

public class GraphicsSettingsTMPDropdown : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;

    void Start()
    {
        // Populate the TMP_Dropdown with the names of quality settings
        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(new System.Collections.Generic.List<string>(QualitySettings.names));

        // Set the dropdown value to the current quality setting
        graphicsDropdown.value = QualitySettings.GetQualityLevel();

        // Add listener to detect when the user changes the dropdown value
        graphicsDropdown.onValueChanged.AddListener(delegate { ChangeGraphicsQuality(graphicsDropdown.value); });
    }

    // Method to change the graphics quality
    public void ChangeGraphicsQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, true); // true means changes apply immediately
        Debug.Log("Graphics Quality set to: " + QualitySettings.names[index]);
    }
}
