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
                buttonText.text = "equipped";
            }
            else
            {
                buttonText.text = "equip";
            }
            _button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            buttonText.text = $"unlocks at level {unlockLevel}";
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
                    btn.buttonText.text = "equip";
                }
                else
                {
                    btn.buttonText.text = $"unlocks at level {btn.unlockLevel}";
                }
            }
        }

        PlayerPrefs.SetInt("wallpaper", int.Parse(gameObject.name));
        buttonText.text = "equipped";
    }
}