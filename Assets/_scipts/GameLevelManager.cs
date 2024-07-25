using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    public static int Level;

    private void Start()
    {
        Level = PlayerPrefs.GetInt("LevelIndex", 0);
    }
}
