using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;  // Import the Timeline namespace
using System.Collections;   // Required for coroutines

public class UniqueTimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public int frameToPauseAt = 8;
    private bool isPaused = false;
    private double frameRate;

    private void Start()
    {
        // Get the frame rate from the timeline's playable asset
        frameRate = playableDirector.playableAsset is TimelineAsset timelineAsset ? timelineAsset.editorSettings.frameRate : 30.0;
    }

    // Call this method when the pause/reset button is pressed
    public void PauseAndResetToFrame8()
    {
        if (playableDirector != null)
        {
            double newTime = frameToPauseAt / frameRate;
            playableDirector.time = newTime;  // Set the timeline to Frame 8
            playableDirector.Evaluate();      // Immediately update the timeline to reflect the new time
            playableDirector.Pause();         // Pause the timeline
            isPaused = true;
        }
    }

    // Call this method when the resume button is pressed
    public void ResumeTimeline()
    {
        if (playableDirector != null && isPaused)
        {
            StartCoroutine(ResumeAfterDelay(1f));  // Start the coroutine with a 1-second delay
        }
    }

    // Coroutine that waits for the specified delay before resuming the timeline
    private IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified time (1 second)
        playableDirector.Play();  // Resume the timeline
        isPaused = false;
    }
}
