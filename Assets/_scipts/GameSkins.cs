using UnityEngine;
using UnityEngine.UI;

public class GameSkins : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Sprite[] _backgroundSprites;
    [SerializeField] private GameObject[] _planes;

    private void Start()
    {
        _backgroundImage.sprite = _backgroundSprites[PlayerPrefs.GetInt("wallpaper", 0)];
        _planes[PlayerPrefs.GetInt("planeSkin", 0)].SetActive(true);
    }
}