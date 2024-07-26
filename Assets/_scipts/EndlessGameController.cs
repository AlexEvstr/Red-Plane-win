using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessGameController : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _gameOver;
    private QuizUI _quizUI;

    private void Start()
    {
        Time.timeScale = 1;
        _quizUI = GetComponent<QuizUI>();
    }

    public void OpenPause()
    {
        _pause.SetActive(true);
        _quizUI.HideQuestion();
        Time.timeScale = 0;
    }

    public void ClosePause()
    {
        _pause.SetActive(false);
        _quizUI.questionPanel.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameplayEndless");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Home");
    }
}