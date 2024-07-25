using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneSkinManager : MonoBehaviour
{
    public int unlockLevel; // Уровень, на котором открывается скин самолета
    public string planeSkinName; // Название скина самолета
    public TMP_Text buttonText; // Текст на кнопке
    public TMP_Text planeSkinNameText; // Текст для отображения названия скина самолета
    private Button _button;
    [SerializeField] private GameObject[] _planes;

    private void Start()
    {
        _button = GetComponent<Button>();
        int playerLevel = PlayerPrefs.GetInt("BestLevelIndex", 1);
        int equippedPlaneSkin = PlayerPrefs.GetInt("planeSkin", -1);

        // Устанавливаем первый скин по умолчанию, если не был выбран другой
        if (equippedPlaneSkin == -1 && int.Parse(gameObject.name) == 0)
        {
            PlayerPrefs.SetInt("planeSkin", 0);
            equippedPlaneSkin = 0;
        }

        if (playerLevel >= unlockLevel)
        {
            if (equippedPlaneSkin == int.Parse(gameObject.name))
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

        planeSkinNameText.text = planeSkinName;
    }

    private void OnButtonClick()
    {
        // Сброс всех других кнопок на "equip"
        PlaneSkinManager[] allButtons = FindObjectsOfType<PlaneSkinManager>();
        foreach (PlaneSkinManager btn in allButtons)
        {
            if (btn != this)
            {
                btn.buttonText.text = "equip";
            }
        }

        PlayerPrefs.SetInt("planeSkin", int.Parse(gameObject.name));
        buttonText.text = "equipped";

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
