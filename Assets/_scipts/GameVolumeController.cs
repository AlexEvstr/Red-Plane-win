using UnityEngine;

public class GameVolumeController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundSource;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SoundVolumeKey = "SoundVolume";

    void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.75f);
        float soundVolume = PlayerPrefs.GetFloat(SoundVolumeKey, 0.75f);

        musicSource.volume = musicVolume;
        soundSource.volume = soundVolume;
    }
}
