using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsGameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
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

    public void ResumeGame()
    {
        _pause.SetActive(false);
        _quizUI.questionPanel.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameplayLevel");
    }
}