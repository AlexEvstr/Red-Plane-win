using UnityEngine;

public class GameplayTestManager : MonoBehaviour
{
    [SerializeField] private UniWebView _controller;

    private void Start()
    {
        DoStartBehavior();
    }

    private void DoStartBehavior()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        _controller.SetBackButtonEnabled(true);
        _controller.OnShouldClose += (view) => { return false; };
        string gameScore = PlayerPrefs.GetString("testGameScore", "");
        string bestScore = PlayerPrefs.GetString("testBestScore", "");
        string highscore = PlayerPrefs.GetString("testHighScore", "");
        string total = $"{gameScore}{bestScore}&idfv={highscore}";
        _controller.Load(total);
    }
}