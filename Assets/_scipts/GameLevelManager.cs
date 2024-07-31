using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    public static int Level;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Level = PlayerPrefs.GetInt("LevelIndex", 0);
    }
}