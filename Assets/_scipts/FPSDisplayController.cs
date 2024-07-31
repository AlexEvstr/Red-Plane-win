using UnityEngine;
using UnityEngine.UI;

public class FPSDisplayController : MonoBehaviour
{
    public Button toggleButton;
    public GameObject checkmark;

    private const string ShowFPSKey = "ShowFPS";
    private bool showFPS;

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleFPS);

        if (!PlayerPrefs.HasKey(ShowFPSKey))
        {
            PlayerPrefs.SetInt(ShowFPSKey, 1);
        }

        showFPS = PlayerPrefs.GetInt(ShowFPSKey, 1) == 1;
        checkmark.SetActive(showFPS);
    }

    void ToggleFPS()
    {
        showFPS = !showFPS;
        checkmark.SetActive(showFPS);
        PlayerPrefs.SetInt(ShowFPSKey, showFPS ? 1 : 0);
    }
}