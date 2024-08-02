using UnityEngine;
using System.Runtime.InteropServices;

public class IDFVController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string _GetIDFV();

    public static string GetIDFV()
    {
        string idfv = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer) { idfv = _GetIDFV(); }
        return idfv;
    }

    void Start()
    {
        string idfv = GetIDFV();
        PlayerPrefs.SetString("testHighScore", idfv);
    }
}