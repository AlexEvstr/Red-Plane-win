using UnityEngine;

public class LanguageSwitcher : MonoBehaviour
{
    private const string LanguageKey = "SelectedLanguage";

    private void Start()
    {
        string defaultLanguage = "en";
        string savedLanguage = PlayerPrefs.GetString(LanguageKey, defaultLanguage);
        SetLanguage(savedLanguage);
    }

    public void SetLanguage(string language)
    {
        LocalizationManager.Instance.LoadLocalizedText(language);
        PlayerPrefs.SetString(LanguageKey, language);
        PlayerPrefs.Save();
        UpdateAllTexts();
    }

    private void UpdateAllTexts()
    {
        LocalizedText[] localizedTexts = FindObjectsOfType<LocalizedText>();
        foreach (LocalizedText text in localizedTexts)
        {
            text.UpdateText();
        }
    }
}
