using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    public FPSCounter fpsCounter;

    private const string ShowFPSKey = "ShowFPS";

    void Start()
    {
        bool showFPS = PlayerPrefs.GetInt(ShowFPSKey, 1) == 1;
        fpsText.gameObject.SetActive(showFPS);

        if (showFPS)
        {
            InvokeRepeating("UpdateFPSText", 0, 0.25f);
        }
    }

    void UpdateFPSText()
    {
        fpsText.text = Mathf.RoundToInt(fpsCounter.GetFPS()).ToString() + " fps";
    }
}