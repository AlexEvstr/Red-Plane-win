using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance { get; private set; }
    private Dictionary<string, string> localizedText;
    private string missingTextString = "Localized text not found";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadLocalizedText(PlayerPrefs.GetString("SelectedLanguage", "en"));
    }

    public void LoadLocalizedText(string language)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = "Localization/" + language + "/strings";

        TextAsset targetFile = Resources.Load<TextAsset>(filePath);

        if (targetFile != null)
        {
            string dataAsJson = targetFile.text;
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            foreach (LocalizationItem item in loadedData.items)
            {
                if (!localizedText.ContainsKey(item.key))
                {
                    localizedText.Add(item.key, item.value);
                }
                
            }
        }
    }

    public string GetLocalizedValue(string key)
    {
        if (localizedText == null)
        {
            return missingTextString;
        }

        if (localizedText.ContainsKey(key))
        {
            return localizedText[key];
        }
        else
        {
            return missingTextString;
        }
    }
}

[System.Serializable]
public class LocalizationData
{
    public LocalizationItem[] items;
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}