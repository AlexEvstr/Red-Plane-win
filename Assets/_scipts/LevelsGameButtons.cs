using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsGameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pause;

    private void Start()
    {
        Time.timeScale = 1;    
    }

    public void OpenPause()
    {
        _pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _pause.SetActive(false);
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
