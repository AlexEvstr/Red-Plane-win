using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessGameController : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _gameOver;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void OpenPause()
    {
        _pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePause()
    {
        _pause.SetActive(false);
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

    public void OpenGameOver()
    {
        StartCoroutine(GameOverOpening());
        Time.timeScale = 0;
    }

    private IEnumerator GameOverOpening()
    {
        yield return new WaitForSeconds(1.5f);
        _gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}