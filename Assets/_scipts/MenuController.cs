using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _levels;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _policy;
    [SerializeField] private GameObject _language;
    [SerializeField] private GameObject[] _planes;
    [SerializeField] private Image _wallpaper;
    [SerializeField] private Sprite[] _wallpapers;

    private void Start()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.Portrait;
        _wallpaper.sprite = _wallpapers[PlayerPrefs.GetInt("wallpaper", 0)];
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
        _language.SetActive(false);
        _menu.SetActive(true);
    }

    public void OpenPolicy()
    {
        _settings.SetActive(false);
        _policy.SetActive(true);
    }

    public void ClosePolicy()
    {
        _policy.SetActive(false);
        _settings.SetActive(true);
    }

    public void OpenLanguage()
    {
        _language.SetActive(true);
    }

    public void CloseLanguage()
    {
        _language.SetActive(false);
    }
}