using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PlayTimelineForwardAndReverse : MonoBehaviour
{
    public Button playButton; // Button to play timeline forward
    public Button reverseButton; // Button to play timeline in reverse
    public PlayableDirector playableDirector; // Reference to the PlayableDirector

    private bool isReversing = false; // Flag to know when the timeline is playing in reverse

    void Start()
    {
        // Ensure the play button is assigned
        if (playButton != null)
        {
            // Add listener to detect forward play button press
            playButton.onClick.AddListener(OnPlayButtonPress);
        }
        else
        {
            Debug.LogError("Play Button is not assigned!");
        }

        // Ensure the reverse button is assigned
        if (reverseButton != null)
        {
            // Add listener to detect reverse play button press
            reverseButton.onClick.AddListener(OnReverseButtonPress);
        }
        else
        {
            Debug.LogError("Reverse Button is not assigned!");
        }

        // Ensure the PlayableDirector is assigned
        if (playableDirector == null)
        {
            Debug.LogError("PlayableDirector is not assigned!");
        }
    }

    // Play the timeline forward
    void OnPlayButtonPress()
    {
        if (playableDirector != null)
        {
            isReversing = false; // Disable reverse playback
            playableDirector.Play(); // Play forward
        }
    }

    // Play the timeline in reverse
    void OnReverseButtonPress()
    {
        if (playableDirector != null)
        {
            isReversing = true; // Enable reverse playback
            playableDirector.Pause(); // Pause the timeline to manually control time
        }
    }

    void Update()
    {
        // Reverse the timeline when reverse is active
        if (isReversing && playableDirector != null)
        {
            // Decrease the timeline's time to play it backward
            playableDirector.time -= Time.deltaTime;

            // Clamp the timeline at the start
            if (playableDirector.time <= 0)
            {
                playableDirector.time = 0;
                isReversing = false; // Stop reversing once the timeline reaches the start
            }

            playableDirector.Evaluate(); // Apply the time change to the timeline
        }
    }
}
