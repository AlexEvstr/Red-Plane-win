using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WallpaperSkinManager : MonoBehaviour
{
    public int unlockLevel; // Уровень, на котором открываются обои
    public string wallpaperName; // Название обоев
    public TMP_Text buttonText; // Текст на кнопке
    public TMP_Text wallpaperNameText; // Текст для отображения названия обоев
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        int playerLevel = PlayerPrefs.GetInt("BestLevelIndex", 1);
        int equippedWallpaper = PlayerPrefs.GetInt("wallpaper", -1);

        // Устанавливаем первый скин по умолчанию, если не был выбран другой
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
        // Сброс всех других кнопок на "equip"
        WallpaperSkinManager[] allButtons = FindObjectsOfType<WallpaperSkinManager>();
        foreach (WallpaperSkinManager btn in allButtons)
        {
            if (btn != this)
            {
                btn.buttonText.text = "equip";
            }
        }

        PlayerPrefs.SetInt("wallpaper", int.Parse(gameObject.name));
        buttonText.text = "equipped";
    }
}
