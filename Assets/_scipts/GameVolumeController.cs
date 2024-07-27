using UnityEngine;

public class GameVolumeController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundSource;
    public AudioClip _clickSound;
    public AudioClip _goodAnswerSound;
    public AudioClip _badAnswerSound;
    public AudioClip _winSound;
    public AudioClip _loseSound;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SoundVolumeKey = "SoundVolume";
    private bool _isVibration;

    void Start()
    {
        _isVibration = PlayerPrefs.GetInt("isVibration", 1) == 1;
        /////////
        //_isVibration = false;
        /////////
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);
        float soundVolume = PlayerPrefs.GetFloat(SoundVolumeKey, 0.75f);

        musicSource.volume = musicVolume;
        soundSource.volume = soundVolume;
    }

    public void ClickSound()
    {
        soundSource.PlayOneShot(_clickSound);
        if (_isVibration) Vibration.VibrateIOS(ImpactFeedbackStyle.Soft);
    }

    public void GoodAnswerSound()
    {
        soundSource.PlayOneShot(_goodAnswerSound);
        if (_isVibration) Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
    }

    public void BadAnswerSound()
    {
        soundSource.PlayOneShot(_badAnswerSound);
        if (_isVibration) Vibration.VibrateIOS(NotificationFeedbackStyle.Error);
    }

    public void WinSound()
    {
        soundSource.PlayOneShot(_winSound);
        if (_isVibration) Vibration.VibrateIOS(ImpactFeedbackStyle.Rigid);
    }

    public void LoseSound()
    {
        soundSource.PlayOneShot(_loseSound);
        if (_isVibration) Vibration.Vibrate();
    }
}
