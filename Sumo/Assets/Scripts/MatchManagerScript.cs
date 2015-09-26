using UnityEngine;
using System.Collections;

public class MatchManagerScript : MonoBehaviour
{
    /// <summary>
    ///  Time after which the round restarts. In seconds.
    /// </summary>
    public float RestartTimeout = 2.0f;
    private bool DidScheduleRestart = false;

    void Start()
    {
        DidScheduleRestart = false;
    }

    public void PlayerDied(string tag)
    {
        if (DidScheduleRestart == false)
        {
            Debug.Log(string.Format("Player with tag {0} died. Restarting match...", tag));

            DidScheduleRestart = true;
            StartCoroutine(RestartAfterTime(RestartTimeout));
        }
    }

    IEnumerator RestartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        /// Restart game
        Application.LoadLevel(Application.loadedLevel);
    }
}
