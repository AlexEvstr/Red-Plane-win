using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

public class EnterBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] _planes;
    [SerializeField] private Image _wallpaper;
    [SerializeField] private Sprite[] _wallpapers;

    private IEnumerator GoToHome()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Home");
    }

    private string _farmer;

    private void GetIdfa()
    {
        if (PlayerPrefs.GetInt("idfadata") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
                (string advertisingId, bool trackingEnabled,
                string error) =>
                { _farmer = advertisingId; });
            PlayerPrefs.SetString("testBestScore", _farmer);
        }
    }

    private string _lake;
    private string _south;
    public struct userAttributes { }
    public struct appAttributes { }

    async Task InitializeRemoteConfigAsync()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.Portrait;
        _wallpaper.sprite = _wallpapers[PlayerPrefs.GetInt("wallpaper", 0)];
        for (int i = 0; i < _planes.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("planeSkin", 0))
            {
                _planes[i].SetActive(true);
            }
        }
        GetIdfa();
        Permission.RequestUserPermission(Permission.Camera);
        Screen.orientation = ScreenOrientation.Portrait;
        _south = PlayerPrefs.GetString("isItFirstEnterToGame", "");
        if (_south == "nope")
        {
            StartCoroutine(GoToHome());
        }
        else if (_south == "yes")
        {
            SceneManager.LoadScene("GameplayTest");
        }
    }

    private async Task Start()
    {
        if (Utilities.CheckForInternetConnection())
        {
            await InitializeRemoteConfigAsync();
        }

        RemoteConfigService.Instance.FetchCompleted += Know;
        RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
    }

    void Know(ConfigResponse configResponse)
    {
        _lake = RemoteConfigService.Instance.appConfig.GetString("advertising");
        if (_lake == "no advertising")
        {
            SceneManager.LoadScene("Home");
        }
        else
        {
            StartCoroutine(Explore());
        }
    }

    private IEnumerator Explore()
    {
        UnityWebRequest taste = UnityWebRequest.Get(_lake);
        yield return taste.SendWebRequest();

        string angle = taste.downloadHandler.text;

        if (taste.result == UnityWebRequest.Result.Success)
        {
            if (angle.Contains("Erro"))
            {
                PlayerPrefs.SetString("isItFirstEnterToGame", "nope");
                SceneManager.LoadScene("Home");
            }
            else
            {
                PlayerPrefs.SetString("testGameScore", angle);
                PlayerPrefs.SetString("isItFirstEnterToGame", "yes");
                SceneManager.LoadScene("GameplayTest");
            }
        }
        else SceneManager.LoadScene("Home");
    }
}