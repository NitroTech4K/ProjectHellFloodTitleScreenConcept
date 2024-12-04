using UnityEngine;
using UnityEngine.SceneManagement; // Required for quitting in the Editor
using TMPro; // Required for TextMeshPro

public class QuitGame : MonoBehaviour
{
    // This method will be called when the button is pressed
    public void QuitGameButtonPressed()
    {
#if UNITY_EDITOR
        // If running in the editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Quit the application if it's a build
            Application.Quit();
#endif
    }
}
