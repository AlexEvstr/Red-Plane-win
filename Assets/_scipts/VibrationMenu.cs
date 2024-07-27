using UnityEngine;
using UnityEngine.UI;

public class VibrationMenu : MonoBehaviour
{
    [SerializeField] private GameObject _vibroMark;
    [SerializeField] private Button toggleButton;
    public static bool isVibration;

    private void Start()
    {
        Vibration.Init();
        toggleButton.onClick.AddListener(ToggleVibration);
        if (!PlayerPrefs.HasKey("isVibration"))
        {
            PlayerPrefs.SetInt("isVibration", 1);
        }
        isVibration = PlayerPrefs.GetInt("isVibration", 1) == 1;
        //////////
        //isVibration = false;
        /////////
        _vibroMark.SetActive(isVibration);
    }

    void ToggleVibration()
    {
        isVibration = !isVibration;
        _vibroMark.SetActive(isVibration);
        PlayerPrefs.SetInt("isVibration", isVibration ? 1 : 0);
    }
}