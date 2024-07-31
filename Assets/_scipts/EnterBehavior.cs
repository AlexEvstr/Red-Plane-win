using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterBehavior : MonoBehaviour
{
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
        StartCoroutine(GoToHome());
    }

    private IEnumerator GoToHome()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Home");
    }
}