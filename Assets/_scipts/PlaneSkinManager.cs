using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneSkinManager : MonoBehaviour
{
    public int unlockLevel;
    public string planeSkinName;
    public TMP_Text buttonText;
    public TMP_Text planeSkinNameText;
    private Button _button;
    [SerializeField] private GameObject[] _planes;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        int playerLevel = PlayerPrefs.GetInt("BestLevelIndex", 1);
        int equippedPlaneSkin = PlayerPrefs.GetInt("planeSkin", -1);

        if (equippedPlaneSkin == -1 && int.Parse(gameObject.name) == 0)
        {
            PlayerPrefs.SetInt("planeSkin", 0);
            equippedPlaneSkin = 0;
        }

        if (playerLevel >= unlockLevel)
        {
            if (equippedPlaneSkin == int.Parse(gameObject.name))
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
            buttonText.text = $"{LocalizationManager.Instance.GetLocalizedValue("unlocks_at_level")} {unlockLevel}";
            _button.interactable = false;
        }

        planeSkinNameText.text = planeSkinName;
    }

    private void OnButtonClick()
    {
        PlaneSkinManager[] allButtons = FindObjectsOfType<PlaneSkinManager>();
        int playerLevel = PlayerPrefs.GetInt("BestLevelIndex", 1);

        foreach (PlaneSkinManager btn in allButtons)
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

        PlayerPrefs.SetInt("planeSkin", int.Parse(gameObject.name));
        buttonText.text = LocalizationManager.Instance.GetLocalizedValue("equipped");

        for (int i = 0; i < _planes.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("planeSkin", 0))
            {
                _planes[i].SetActive(true);
            }
            else
            {
                _planes[i].SetActive(false);
            }
        }
    }
}