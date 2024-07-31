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

    void Start()
    {   
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);
        float soundVolume = PlayerPrefs.GetFloat(SoundVolumeKey, 0.75f);

        musicSource.volume = musicVolume;
        soundSource.volume = soundVolume;
    }

    public void ClickSound()
    {
        soundSource.PlayOneShot(_clickSound);
    }

    public void GoodAnswerSound()
    {
        soundSource.PlayOneShot(_goodAnswerSound);
    }

    public void BadAnswerSound()
    {
        soundSource.PlayOneShot(_badAnswerSound);
    }

    public void WinSound()
    {
        soundSource.PlayOneShot(_winSound);
    }

    public void LoseSound()
    {
        soundSource.PlayOneShot(_loseSound);
    }
}