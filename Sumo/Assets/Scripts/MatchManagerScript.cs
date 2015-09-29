using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchManagerScript : MonoBehaviour
{
    /// <summary>
    ///  Time after which the round restarts. In seconds.
    /// </summary>
    public float RestartTimeout = 2.0f;
    public Text VictoryText = null;
    private bool DidScheduleRestart = false;

    void Start()
    {
        if (VictoryText != null)
        {
            VictoryText.text = "";
        }
        DidScheduleRestart = false;
    }

    public void PlayerDied(string tag)
    {
        if (DidScheduleRestart == false)
        {
            DidScheduleRestart = true;
            SetVictoryStringForLosingPlayerWithTag(tag);
            StartCoroutine(RestartAfterTime(RestartTimeout));
        }
    }

    /// <summary>
    /// Sets victory text to a basic message.
    /// </summary>
    /// <param name="victorTag"></param>
    private void SetVictoryStringForLosingPlayerWithTag(string victorTag)
    {
        if (VictoryText != null)
        {
            string text = "Player ";
            if (victorTag == "Player2")
            {
                text += "1";
            }
            else
            {
                text += "2";
            }
            text += " won the round!";

            VictoryText.text = text;
        }
    }

    IEnumerator RestartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        /// Restart game
        Application.LoadLevel(Application.loadedLevel);
    }
}
