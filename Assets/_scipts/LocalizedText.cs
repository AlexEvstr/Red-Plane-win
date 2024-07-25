using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    public string key;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        if (_text != null)
        {
            UpdateText();
        }
    }

    public void UpdateText()
    {
        if (LocalizationManager.Instance == null)
        {
            return;
        }

        string localizedValue = LocalizationManager.Instance.GetLocalizedValue(key);
        if (localizedValue == null)
        {
            _text.text = "Missing text";
            return;
        }

        _text.text = localizedValue;
    }

    public void SetKey(string newKey)
    {
        key = newKey;
        UpdateText();
    }
}
