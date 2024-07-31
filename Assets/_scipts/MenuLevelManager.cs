using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevelManager : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(GoToGame);

        int levelIndex = int.Parse(gameObject.name);
        int stars = PlayerPrefs.GetInt("Level_" + levelIndex + "_Stars", 0);
        int bestLevel = PlayerPrefs.GetInt("BestLevelIndex", 1);

        if (bestLevel >= levelIndex)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            _button.enabled = false;
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
        }

        if (stars == 0)
        {
            transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (stars == 1)
        {
            transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (stars == 2)
        {
            transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void GoToGame()
    {
        PlayerPrefs.SetInt("LevelIndex", int.Parse(gameObject.name));
        SceneManager.LoadScene("GameplayLevel");
    }
}