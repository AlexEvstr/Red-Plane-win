using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        string savedLanguage = PlayerPrefs.GetString("SelectedLanguage", "en");
        LocalizationManager.Instance.LoadLocalizedText(savedLanguage);
    }
}
