using UnityEngine;
using TMPro;

public class EndlessScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestScoreText;

    public static int Score;
    private int _bestScore;

    private void Start()
    {
        Score = 0;
        _bestScore = PlayerPrefs.GetInt("EndlessBestScore", 0);
        _bestScoreText.text = $"{_bestScore}";
    }

    private void Update()
    {
        _scoreText.text = $"{Score}";
        if (Score > _bestScore)
        {
            _bestScore = Score;
            PlayerPrefs.SetInt("EndlessBestScore", _bestScore);
            _bestScoreText.text = $"{_bestScore}";
        }
    }
}