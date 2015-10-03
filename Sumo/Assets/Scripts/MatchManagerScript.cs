using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchManagerScript : MonoBehaviour
{
    /// <summary>
    ///  Time after which the round restarts. In seconds.
    /// </summary>
    public float RestartTimeout = 2.0f;

    public GameObject explosionPrefab;

    public Text VictoryText = null;
    private bool DidScheduleRestart = false;

    private static MatchManagerScript _instance;

    public static MatchManagerScript Instance
    {
        get { return _instance; }
    }

    public int Score1
    {
        get
        {
            return PlayerPrefs.GetInt("Score1");
        }
        set
        {
            PlayerPrefs.SetInt("Score1", value);
        }
    }

    public int Score2
    {
        get
        {
            return PlayerPrefs.GetInt("Score2");
        }
        set
        {
            PlayerPrefs.SetInt("Score2", value);
        }
    }

    public void Awake()
    {
        _instance = this;
        if (VictoryText != null)
        {
            VictoryText.text = "";
        }
        DidScheduleRestart = false;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Reset") == true)
        {
            Score1 = Score2 = 0;
        }
        if (Input.GetButtonDown("Quit") == true)
        {
            Application.Quit();
        }
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
                Score1 += 1;
                text += "1";
            }
            else
            {
                Score2 += 1;
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
