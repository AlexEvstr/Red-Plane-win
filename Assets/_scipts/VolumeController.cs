using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioSource musicSource;
    public AudioSource soundSource;
    public AudioClip clickSound;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SoundVolumeKey = "SoundVolume";

    void Start()
    {
        musicSlider.onValueChanged.AddListener(delegate { OnMusicSliderChanged(); });
        soundSlider.onValueChanged.AddListener(delegate { OnSoundSliderChanged(); });

        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);
        float soundVolume = PlayerPrefs.GetFloat(SoundVolumeKey, 0.75f);

        musicSource.volume = musicVolume;
        soundSource.volume = soundVolume;

        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;
    }

    public void OnMusicSliderChanged()
    {
        float volume = musicSlider.value;
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    public void OnSoundSliderChanged()
    {
        float volume = soundSlider.value;
        soundSource.volume = volume;
        PlayerPrefs.SetFloat(SoundVolumeKey, volume);
    }

    public void ClickSound()
    {
        soundSource.PlayOneShot(clickSound);
        if (VibrationMenu.isVibration) Vibration.VibrateIOS(ImpactFeedbackStyle.Soft);
    }
}
