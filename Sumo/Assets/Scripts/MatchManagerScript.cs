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

    public bool IsMultiplayer = true;

    public Text TimerText = null;

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

    float TimeSinceStart = 0.0f;

    bool MatchEnded = false;

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
            Application.LoadLevel("MenuScene");
        }

        UpdateTimeSinceStart();
    }

    void UpdateTimeSinceStart()
    {
        TimeSinceStart += Time.deltaTime;
        
        UpdateTimeSinceStartText();
    }

    void UpdateTimeSinceStartText()
    {
        if (TimerText != null && MatchEnded == false)
        {
            string text = string.Format("{0:0.00}s", TimeSinceStart);

            TimerText.text = text;
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
        if (MatchEnded == false)
        {
            MatchEnded = true;

            if (VictoryText != null)
            {
                string text = "Player ";

                if (IsMultiplayer == true)
                {
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
                }
                else
                {
                    text = "Attempt unsuccessful, try again.";
                }

                VictoryText.text = text;
            }
        }
    }

    IEnumerator RestartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        LevelSelectSceneManagerScript.LoadNextLevel();
    }

    public void DidReachFinish()
    {
        if (MatchEnded == false)
        {
            MatchEnded = true;

            string text = string.Format("Victory! The course took you {0} seconds to complete!\nPress Q to go back to the menu.", TimeSinceStart);

            VictoryText.text = text;
        }
    }
}
