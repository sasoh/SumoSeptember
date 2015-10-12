using UnityEngine;
using System.Collections;

public class MenuSceneManagerScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        // reset scores for players
        PlayerPrefs.SetInt("Score1", 0);
        PlayerPrefs.SetInt("Score2", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Loads match scene after pressing the play button.
    /// </summary>
    public void DidPressButtonPlay()
    {
        Application.LoadLevel("LevelSelectionScene");
    }

    /// <summary>
    /// Loads credits scene.
    /// </summary>
    public void DidPressButtonCredits()
    {

    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void DidPressButtonExit()
    {
        Application.Quit();
    }
}
