using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _levels;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject[] _planes;

    private void Start()
    {
        Time.timeScale = 1;
        for (int i = 0; i < _planes.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("planeSkin", 0))
            {
                _planes[i].SetActive(true);
            }
        }
        _shop.SetActive(false);
    }

    public void StartEndlessGame()
    {
        SceneManager.LoadScene("GameplayEndless");
    }

    public void OpenLevels()
    {
        _menu.SetActive(false);
        _levels.SetActive(true);
    }

    public void CloseLevels()
    {
        _levels.SetActive(false);
        _menu.SetActive(true);
    }

    public void OpenShop()
    {
        _menu.SetActive(false);
        _shop.SetActive(true);
    }

    public void CloseShop()
    {
        _shop.SetActive(false);
        _menu.SetActive(true);
    }

    public void OpenSettings()
    {
        _menu.SetActive(false);
        _settings.SetActive(true);
    }

    public void CloseSettings()
    {
        _settings.SetActive(false);
        _menu.SetActive(true);
    }
}