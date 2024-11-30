using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector; // Reference to the PlayableDirector
    public Button playButton; // Button to trigger normal play

    private void Start()
    {
        // Ensure the play button is connected
        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayTimeline);
        }
    }

    // Method to play the timeline forward
    private void PlayTimeline()
    {
        if (playableDirector != null)
        {
            playableDirector.time = 0; // Reset timeline to start
            playableDirector.Play(); // Play forward
        }
    }
}
