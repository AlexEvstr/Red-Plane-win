using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WallpaperSkinManager : MonoBehaviour
{
    public int unlockLevel;
    public string wallpaperName;
    public TMP_Text buttonText;
    public TMP_Text wallpaperNameText;
    private Button _button;
    [SerializeField] private Image _wallpaper;
    [SerializeField] private Sprite[] _wallpapers;

    private void Start()
    {
        _button = GetComponent<Button>();
        int playerLevel = PlayerPrefs.GetInt("BestLevelIndex", 1);
        int equippedWallpaper = PlayerPrefs.GetInt("wallpaper", -1);

        if (equippedWallpaper == -1 && int.Parse(gameObject.name) == 0)
        {
            PlayerPrefs.SetInt("wallpaper", 0);
            equippedWallpaper = 0;
        }

        if (playerLevel >= unlockLevel)
        {
            if (equippedWallpaper == int.Parse(gameObject.name))
            {
                buttonText.text = LocalizationManager.Instance.GetLocalizedValue("equipped");
            }
            else
            {
                buttonText.text = LocalizationManager.Instance.GetLocalizedValue("equip");
            }
            _button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            string unlockText = LocalizationManager.Instance.GetLocalizedValue("unlocks_at_level");
            buttonText.text = $"{unlockText} {unlockLevel}";
            _button.interactable = false;
        }

        wallpaperNameText.text = wallpaperName;
    }

    private void OnButtonClick()
    {
        WallpaperSkinManager[] allButtons = FindObjectsOfType<WallpaperSkinManager>();
        int playerLevel = PlayerPrefs.GetInt("BestLevelIndex", 1);

        foreach (WallpaperSkinManager btn in allButtons)
        {
            if (btn != this)
            {
                if (playerLevel >= btn.unlockLevel)
                {
                    btn.buttonText.text = LocalizationManager.Instance.GetLocalizedValue("equip");
                }
                else
                {
                    btn.buttonText.text = $"{LocalizationManager.Instance.GetLocalizedValue("unlocks_at_level")} {btn.unlockLevel}";
                }
            }
        }

        PlayerPrefs.SetInt("wallpaper", int.Parse(gameObject.name));
        buttonText.text = LocalizationManager.Instance.GetLocalizedValue("equipped");
        _wallpaper.sprite = _wallpapers[PlayerPrefs.GetInt("wallpaper", 0)];
    }
}