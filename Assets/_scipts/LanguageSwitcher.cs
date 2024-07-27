using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageSwitcher : MonoBehaviour
{
    private const string LanguageKey = "SelectedLanguage";

    private void Start()
    {
        string defaultLanguage = "en";
        string savedLanguage = PlayerPrefs.GetString(LanguageKey, defaultLanguage);

        LocalizationManager.Instance.LoadLocalizedText(savedLanguage);
        PlayerPrefs.SetString(LanguageKey, savedLanguage);
        PlayerPrefs.Save();
        UpdateAllTexts();
    }

    public void SetLanguage(string language)
    {
        LocalizationManager.Instance.LoadLocalizedText(language);

        PlayerPrefs.SetString(LanguageKey, language);
        PlayerPrefs.Save();
        UpdateAllTexts();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагрузка текущей сцены для применения изменений
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
