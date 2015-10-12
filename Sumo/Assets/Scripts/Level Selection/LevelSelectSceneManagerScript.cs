using UnityEngine;
using System.Collections.Generic;

public class LevelSelectSceneManagerScript : MonoBehaviour
{
    public static string LevelKey = "LevelSelected";
    public int LevelSelected
    {
        get
        {
            return PlayerPrefs.GetInt(LevelKey);
        }
        set
        {
            PlayerPrefs.SetInt(LevelKey, value);
        }
    }

    public static string[] LevelSceneNames =
        {
            "MatchScene",
            "MatchSceneHole",
            "MatchSceneSquare"
        };

    void Start()
    {
        // reset selection
        LevelSelected = 1;
    }

    public void DidPressButtonPlay()
    {
        // start game
        LevelSelectSceneManagerScript.LoadNextLevel();
    }

    public void DidPressButtonLevel(int levelNumber)
    {
        LevelSelected = levelNumber;
    }

    /// <summary>
    /// Loads next level according to selection from level select scene.
    /// </summary>
    public static void LoadNextLevel()
    {
        int selectedLevel = 0;
        if (PlayerPrefs.HasKey(LevelKey) == true)
        {
            selectedLevel = PlayerPrefs.GetInt(LevelKey);
        }

        int sceneIndex = selectedLevel;
        if (selectedLevel == LevelSceneNames.Length)
        {
            sceneIndex = Random.Range(0, LevelSceneNames.Length);
        }
        Application.LoadLevel(LevelSceneNames[sceneIndex]);
    }
}
