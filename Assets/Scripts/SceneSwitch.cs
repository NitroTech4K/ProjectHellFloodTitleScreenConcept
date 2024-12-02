using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineSceneChanger : MonoBehaviour
{
    public PlayableDirector timelineDirector; // Reference to the PlayableDirector component
    public string nextSceneName; // Name of the next scene to load

    void Start()
    {
        if (timelineDirector != null)
        {
            // Subscribe to the "stopped" event of the PlayableDirector
            timelineDirector.stopped += OnTimelineStopped;
        }
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        if (director == timelineDirector)
        {
            // Load the next scene when the timeline stops
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when this object is destroyed
        if (timelineDirector != null)
        {
            timelineDirector.stopped -= OnTimelineStopped;
        }
    }
}
